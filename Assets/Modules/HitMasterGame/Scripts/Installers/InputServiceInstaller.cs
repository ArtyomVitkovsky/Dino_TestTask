using Modules.Main.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Installers
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private InputService inputServicePrefab;
        public override void InstallBindings()
        {
            var inputServiceInstance = Container
                .InstantiatePrefabForComponent<InputService>(inputServicePrefab);
    
            Container.Bind<InputService>().FromInstance(inputServiceInstance).AsSingle();
        }
    }
}