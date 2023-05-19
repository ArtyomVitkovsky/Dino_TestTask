using Modules.Main.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Modules.Main.Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private InputService inputService;
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private UIManager uiManager;
        
        public override void InstallBindings()
        {
            BindInputService();
            
            BindUIManager();

            BindSceneLoader();
        }
        
        private void BindInputService()
        {
            var inputServiceInstance = Container.InstantiatePrefabForComponent<InputService>(inputService);
            
            Container
                .Bind<InputService>()
                .FromInstance(inputServiceInstance)
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            var sceneLoaderInstance = Container
                .InstantiatePrefabForComponent<SceneLoader>(sceneLoader);

            Container
                .Bind<SceneLoader>()
                .FromInstance(sceneLoaderInstance)
                .AsSingle();
        }
        
        private void BindUIManager()
        {
            var uiManagerInstance = Container
                .InstantiatePrefabForComponent<UIManager>(uiManager);

            Container
                .Bind<UIManager>()
                .FromInstance(uiManagerInstance)
                .AsSingle();
        }
    }
}