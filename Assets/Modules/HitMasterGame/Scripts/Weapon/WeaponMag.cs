using System.Collections;
using Modules.HitMasterGame.Scripts.ObjectsPool;
using Modules.HitMasterGame.Scripts.Weapon.Projectile.Interfaces;
using UnityEngine;
using Zenject;

namespace Modules.Game.Scripts.Weapon
{
    public class WeaponMag : MonoBehaviour
    {
        [SerializeField] private int capacity;
        [SerializeField] private float reloadSpeed;
        [SerializeField] private ObjectsPool<IProjectile> projectilesPool;

        private bool isUnloaded;
        private bool isLoaded;

        private IProjectileFactory projectileFactory;

        public bool IsLoaded => isLoaded;


        [Inject]
        public void Construct(IProjectileFactory projectileFactory)
        {
            this.projectileFactory = projectileFactory;
        }

        private void Start()
        {
            projectilesPool = new ObjectsPool<IProjectile>(transform, capacity, true);

            for (int i = 0; i < capacity; i++)
            {
                var projectileInstance = projectileFactory.Create(transform.position, transform);
                projectilesPool.AddObjectToPool(new PoolObject<IProjectile>(projectileInstance));
            }

            isLoaded = true;
        }

        public IProjectile RetrieveProjectile()
        {
            var freeProjectile = projectilesPool.GetFreeElement();

            isUnloaded = !projectilesPool.IsHasFreeElements();

            if (isUnloaded)
            {
                Reload();
            }
            
            return freeProjectile?.instance;
        }

        private void Reload()
        {
            StartCoroutine(ReloadCoroutine());
        }

        private IEnumerator ReloadCoroutine()
        {
            for (int i = 0; i < capacity; i++)
            {
                projectilesPool.ReleaseFirstOccupiedObject();

                yield return new WaitForSeconds(reloadSpeed / capacity);
            }

            isLoaded = true;
        }
    }
}