using Modules.Game.Scripts;
using Modules.HitMasterGame.Scripts.Weapon.Projectile.Factory;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Installers
{
    public class ProjectileFactoryInstaller : MonoInstaller
    {
        [SerializeField] private ProjectileFactory projectileFactory;
        public override void InstallBindings()
        {
            Container.Bind<IProjectileFactory>().FromInstance(projectileFactory).AsSingle();
        }
    }
}