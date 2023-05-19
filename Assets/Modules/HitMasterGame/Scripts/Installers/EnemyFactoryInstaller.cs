using Modules.Game.Scripts;
using Modules.HitMasterGame.Scripts.Enemy.Factory;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Installers
{
    public class EnemyFactoryInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFactory enemyFactory;
        public override void InstallBindings()
        {
            Container.Bind<IEnemyFactory>().FromInstance(enemyFactory).AsSingle();
        }
    }
}