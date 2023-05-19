using Modules.Game.Scripts;
using Modules.HitMasterGame.Scripts.Weapon.Projectile.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Weapon.Projectile.Factory
{
    public class ProjectileFactory : MonoBehaviour, IProjectileFactory
    {
        [SerializeField] private Projectile projectilePrefab;
        [Inject] private IInstantiator instantiator;

        public IProjectile Create()
        {
            var projectile = instantiator
                .InstantiatePrefabForComponent<Projectile>(projectilePrefab);
            return projectile;
        }

        public IProjectile Create(Vector3 startPosition)
        {
            var projectile = instantiator
                .InstantiatePrefabForComponent<IProjectile>(
                    projectilePrefab, 
                    startPosition, 
                    Quaternion.identity, 
                    null);
            return projectile;
        }

        public IProjectile Create(Vector3 startPosition, Transform parent)
        {
            var projectile = instantiator
                .InstantiatePrefabForComponent<IProjectile>(
                    projectilePrefab, 
                    startPosition,
                    Quaternion.identity, 
                    parent);
            
            return projectile;
        }

        public IProjectile Create(Vector3 startPosition, Vector3 rotation, Transform parent)
        {
            var projectile = instantiator
                .InstantiatePrefabForComponent<IProjectile>(
                    projectilePrefab, 
                    startPosition, 
                    Quaternion.Euler(rotation),
                    parent);
            
            return projectile;
        }
    }
}