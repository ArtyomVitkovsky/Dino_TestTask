using Modules.Game.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Enemy.Factory
{
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Enemy enemyPrefab;
        [Inject] private IInstantiator instantiator;

        public Enemy Create()
        {
            var enemy = instantiator.InstantiatePrefabForComponent<Enemy>(enemyPrefab);
            return enemy;
        }

        public Enemy Create(Transform parent)
        {
            var enemy = instantiator
                .InstantiatePrefabForComponent<Enemy>(
                    enemyPrefab, 
                    parent);

            return enemy;
        }

        public Enemy Create(Vector3 startPosition)
        {
            var enemy = instantiator
                .InstantiatePrefabForComponent<Enemy>(
                    enemyPrefab, 
                    startPosition, 
                    Quaternion.identity, 
                    null);

            return enemy;
        }

        public Enemy Create(Vector3 startPosition, Transform parent)
        {
            var enemy = instantiator
                .InstantiatePrefabForComponent<Enemy>(
                    enemyPrefab, 
                    startPosition,
                    Quaternion.identity, 
                    parent);
            
            return enemy;
        }

        public Enemy Create(Vector3 startPosition, Vector3 rotation, Transform parent)
        {
            var enemy = instantiator
                .InstantiatePrefabForComponent<Enemy>(
                    enemyPrefab, 
                    startPosition, 
                    Quaternion.Euler(rotation),
                    parent);
            
            return enemy;
        }
    }
}