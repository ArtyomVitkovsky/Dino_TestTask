using UnityEngine;

namespace Modules.HitMasterGame.Scripts.Weapon.Interfaces
{
    public interface IWeapon
    {
        public void PerformAttack();
        
        public void PerformAttack(Vector3 target);
    }
}