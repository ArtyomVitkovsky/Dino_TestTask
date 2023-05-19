using Modules.HitMasterGame.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Installers
{
    public class PathwayInstaller : MonoInstaller
    {
        [SerializeField] private Pathway pathway;
        public override void InstallBindings()
        {
            Container.Bind<Pathway>().FromInstance(pathway).AsSingle();
        }
    }
}