using Modules.HitMasterGame.Scripts.Enemy;
using UnityEngine;

namespace Modules.Game.Scripts
{
    interface IEnemyFactory
    {
        public Enemy Create();
        public Enemy Create(Transform parent);
        public Enemy Create(Vector3 startPosition);
        public Enemy Create(Vector3 startPosition, Transform parent);
        public Enemy Create(Vector3 startPosition, Vector3 rotation ,Transform parent);
    }
}