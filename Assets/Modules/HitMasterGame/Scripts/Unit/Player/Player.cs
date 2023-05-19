using System;
using Modules.HitMasterGame.Scripts.Player;
using Modules.HitMasterGame.Scripts.Weapon.Interfaces;
using Modules.Main.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Unit.Player
{
    public class Player : Scripts.Unit.Unit
    {
        [SerializeField] protected UnitBattleStats unitBattleStats;

        private IWeapon weapon;
        private InputService inputService;
        [Inject]
        private void Construct(IWeapon weapon, InputService inputService)
        {
            this.weapon = weapon;

            SetupInput(inputService);
        }

        private void SetupInput(InputService inputService)
        {
            this.inputService = inputService;
        
            this.inputService.OnTouchRelease += weapon.PerformAttack;
        }

        private void OnDestroy()
        {
            inputService.OnTouchRelease -= weapon.PerformAttack;
        }
    }
}