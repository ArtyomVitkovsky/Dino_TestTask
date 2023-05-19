using System;
using Modules.Game.Scripts.Weapon;
using Modules.HitMasterGame.Scripts.Player;
using Modules.HitMasterGame.Scripts.Weapon.Interfaces;
using Modules.Main.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Weapon
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeField] private WeaponMag mag;
        [SerializeField] private float fireDelay;
        [SerializeField] private float distance;
        
        private float lastFireDelay;

        private InputService inputService;
        private PlayerCamera playerCamera;
        [Inject]
        private void Construct(InputService inputService, PlayerCamera playerCamera)
        {
            this.playerCamera = playerCamera;
            
            this.inputService = inputService;
            this.inputService.OnTouch += LookAt;

        }

        private void LookAt(Vector3 position)
        {
            Ray ray = playerCamera.Camera.ScreenPointToRay(position);
            Physics.Raycast(ray, out var hitInfo);
            
            transform.LookAt(hitInfo.point);
        }

        public void PerformAttack()
        {
            
        }

        public void PerformAttack(Vector3 position)
        {
            if(GameSettings.IS_PAUSED) return;
            
            if (mag.IsLoaded && lastFireDelay >= fireDelay)
            {
                Ray ray = playerCamera.Camera.ScreenPointToRay(position);
                Physics.Raycast(ray, out var hitInfo);

                var projectile = mag.RetrieveProjectile();
                projectile.SetTargetDestination(hitInfo.point);
                lastFireDelay = 0;
            }
        }

        private void Update()
        {
            lastFireDelay += Time.deltaTime;
        }

        private void OnDestroy()
        {
            inputService.OnTouch -= LookAt;
        }
    }
}