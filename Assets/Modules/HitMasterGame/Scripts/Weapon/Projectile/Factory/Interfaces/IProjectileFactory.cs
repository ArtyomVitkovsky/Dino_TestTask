using Modules.HitMasterGame.Scripts.Weapon.Projectile.Interfaces;
using UnityEngine;

namespace Modules.Game.Scripts
{
    public interface IProjectileFactory
    {
        public IProjectile Create();
        public IProjectile Create(Vector3 startPosition);
        public IProjectile Create(Vector3 startPosition, Transform parent);
        public IProjectile Create(Vector3 startPosition, Vector3 rotation ,Transform parent);
    }
}