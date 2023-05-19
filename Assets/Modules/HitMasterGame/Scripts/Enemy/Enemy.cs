using Modules.HitMasterGame.Scripts.Unit;
using Modules.HitMasterGame.Scripts.Weapon.Projectile.Interfaces;
using UnityEngine;

namespace Modules.HitMasterGame.Scripts.Enemy
{
    public class Enemy : Unit.Unit
    {
        [SerializeField] protected UnitBattleStats unitBattleStats;

        public UnitBattleStats BattleStats => unitBattleStats;

        public override void Start()
        {
            base.Start();
            unitBattleStats.ClearHealth.OnChanged += StatsMonitor.CheckHealth;
            unitView.RagdollSystem.Disable();
        }

        public override void OnProjectileHit(IProjectile projectile)
        {
            base.OnProjectileHit(projectile);

            unitBattleStats.ReceiveDamage(projectile.GetDamage());
        }
    }
}
