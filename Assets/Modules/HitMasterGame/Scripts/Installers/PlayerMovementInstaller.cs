using Modules.HitMasterGame.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Installers
{
    public class PlayerMovementInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovement playerMovement;
        public override void InstallBindings()
        {
            Container.Bind<PlayerMovement>().FromInstance(playerMovement).AsSingle();
        }
    }
}