using UnityEngine;
using Zenject;

namespace Modules.Main.Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private InputService inputService;
        
        public override void InstallBindings()
        {
            BindInputService();

        }
        
        private void BindInputService()
        {
            Container
                .Bind<InputService>()
                .FromInstance(inputService)
                .AsSingle();
        }
    }
}