using Modules.HitMasterGame.Scripts.Weapon.Interfaces;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Installers
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] Weapon.Weapon weapon;
        public override void InstallBindings()
        {
            Container.Bind<IWeapon>().FromInstance(weapon).AsSingle();
        }
    }
}