using UnityEngine;

namespace Modules.HitMasterGame.Scripts.Weapon.Projectile.Interfaces
{
    public interface IProjectile
    {
        public void Damage();
        
        public void SetTargetDestination(Vector3 target);

        public float GetDamage();
        
        public float GetHitForce();

    }
}