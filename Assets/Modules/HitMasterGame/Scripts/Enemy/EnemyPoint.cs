using System;
using System.Collections.Generic;
using System.Linq;
using Modules.HitMasterGame.Scripts.Player;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Enemy
{
    public class EnemyPoint : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private WayPoint wayPoint;

        private bool isEnemyPointPassed;

        public UnityAction<EnemyPoint> OnEnemyPointPassed;
        public UnityAction<EnemyPoint> OnEnemyDeath;
        
        public WayPoint WayPoint => wayPoint;

        public bool IsEnemyPointPassed => isEnemyPointPassed;

        private void Start()
        {
            foreach (var enemy in enemySpawner.EnemyPool.Pool)
            {
                enemy.instance.StatsMonitor.OnDeath += CheckAliveUnits;
            }
        }

        private void CheckAliveUnits()
        {
            OnEnemyDeath?.Invoke(this);
            
            foreach (var enemy in enemySpawner.EnemyPool.Pool)
            {
                if(enemy.instance.StatsMonitor.IsDead == false) return;
            }

            isEnemyPointPassed = true;
            OnEnemyPointPassed?.Invoke(this);
        }

        public Enemy GetClosestEnemy(Transform point)
        {
            var enemyPoolObject = enemySpawner.EnemyPool.Pool
                .FirstOrDefault(e => !e.instance.StatsMonitor.IsDead);
            
            if (enemyPoolObject == null) return null;
            
            var closestEnemy = enemyPoolObject.instance;
            var distance = Vector3.Distance(point.position, closestEnemy.transform.position);
            foreach (var enemy in enemySpawner.EnemyPool.Pool)
            {
                if(enemy.instance.StatsMonitor.IsDead) continue;
                
                var temp = Vector3.Distance(point.position, enemy.instance.transform.position);
                if (temp < distance)
                {
                    distance = temp;
                    closestEnemy = enemy.instance;
                }
            }

            return closestEnemy;
        }
    }
}