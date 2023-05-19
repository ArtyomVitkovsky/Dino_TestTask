using System;
using System.Collections.Generic;
using Modules.HitMasterGame.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Enemy
{
    public class EnemySystem : MonoBehaviour
    {
        [SerializeField] private List<EnemyPoint> enemyPoints;

        private PlayerMovement playerMovement;

        [Inject]
        private void Construct(PlayerMovement playerMovement)
        {
            this.playerMovement = playerMovement;
            this.playerMovement.OnWayPointReached += NextEnemyPoint;
        }

        private void Start()
        {
            foreach (var enemyPoint in enemyPoints)
            {
                enemyPoint.OnEnemyPointPassed += OnEnemyPointOnEnemyPointPassed;
                enemyPoint.OnEnemyDeath += LookAtClosestEnemy;
            }
        }

        private void OnEnemyPointOnEnemyPointPassed(EnemyPoint enemyPoint)
        {
            if (enemyPoint.WayPoint == playerMovement.GetCurrentWayPoint())
            {
                playerMovement.SetNextPointDestination();
            }
        }

        private void NextEnemyPoint(WayPoint wayPoint)
        {
            foreach (var enemyPoint in enemyPoints)
            {
                if (enemyPoint.WayPoint == wayPoint)
                {
                    if (enemyPoint.IsEnemyPointPassed)
                    {
                        playerMovement.SetNextPointDestination();
                    }
                    else
                    {
                        LookAtClosestEnemy(enemyPoint);
                    }
                }
               
            }
        }

        private void LookAtClosestEnemy(EnemyPoint enemyPoint)
        {
            var enemy = enemyPoint.GetClosestEnemy(playerMovement.transform);
            if(enemy == null) return;
            
            playerMovement.SetLookTarget(enemy.transform);
        }
    }
}