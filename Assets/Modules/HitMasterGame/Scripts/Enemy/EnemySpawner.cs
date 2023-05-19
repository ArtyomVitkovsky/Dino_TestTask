using System;
using System.Collections.Generic;
using Modules.Game.Scripts;
using Modules.HitMasterGame.Scripts.ObjectsPool;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private int poolSize;
        [SerializeField] private List<Transform> spawnPositions;
        private ObjectsPool<Enemy> enemyPool;
        
        
        private IEnemyFactory _enemyFactory;

        public ObjectsPool<Enemy> EnemyPool => enemyPool;

        [Inject]
        private void Construct(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void OnValidate()
        {
            if(spawnPositions.Capacity < poolSize) return;
            
            if (spawnPositions.Count < poolSize)
            {
                for (int i = 0; i < poolSize; i++)
                {
                    spawnPositions.Add(null);
                }
            }
        }

        private void Start()
        {
            enemyPool = new ObjectsPool<Enemy>(transform, poolSize, true);

            for (int i = 0; i < poolSize; i++)
            {
                var spawnPosition = spawnPositions[i];
                var enemy = _enemyFactory.Create(spawnPosition);
                enemyPool.AddObjectToPool(new PoolObject<Enemy>(enemy, enemy.gameObject));
            }
        }
    }
}