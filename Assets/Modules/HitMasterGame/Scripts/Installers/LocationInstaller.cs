using Modules.HitMasterGame.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Unit.Player.Player player;
        [SerializeField] private PlayerCamera playerCamera;
        public override void InstallBindings()
        {
            BindPlayer();
            
            BindPlayerCamera();
        }

        

        private void BindPlayerCamera()
        {
            Container
                .Bind<PlayerCamera>()
                .FromInstance(playerCamera)
                .AsSingle();
        }

        private void BindPlayer()
        {
            Container
                .Bind<Unit.Player.Player>()
                .FromInstance(player)
                .AsSingle();
        }

        
    }
}