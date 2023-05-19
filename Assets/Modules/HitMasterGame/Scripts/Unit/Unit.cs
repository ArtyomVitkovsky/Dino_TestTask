using System;
using Modules.HitMasterGame.Scripts.Weapon.Projectile.Interfaces;
using UnityEngine;

namespace Modules.HitMasterGame.Scripts.Unit
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] protected UnitStatsMonitor unitStatsMonitor;
        [SerializeField] protected UnitMovementStats unitMovementStats;
        [SerializeField] protected UnitView unitView;
        [SerializeField] protected float movementCheckFrequency;

        protected UnitState currentState;

        protected IProjectile lastProjectile;

        private Vector3 lastPosition;

        private float timeFromLastMovementCheck;

        private bool isMoving;

        public UnitMovementStats MovementStats => unitMovementStats;

        public UnitStatsMonitor StatsMonitor => unitStatsMonitor;

        public UnitView View => unitView;


        public virtual void Start()
        {
            lastPosition = transform.position;

            unitView.OnProjectileHit += OnProjectileHit;

            unitStatsMonitor.OnDeath += OnDeath;
            
            unitView.SetState(UnitState.Idle);
        }

        private void Update()
        {
            IsMoving();
        }

        private void IsMoving()
        {
            timeFromLastMovementCheck += Time.deltaTime;
            if (timeFromLastMovementCheck > movementCheckFrequency)
            {
                Debug.Log("Movement check");
                timeFromLastMovementCheck = 0;
                var distance = Vector3.Distance(lastPosition, transform.position);
                isMoving =  distance != 0;
                lastPosition = transform.position;
                
                if (isMoving)
                {
                    if(currentState != UnitState.Walking) unitView.SetState(UnitState.Walking);
                    currentState = UnitState.Walking;
                }
                else
                {
                    if(currentState != UnitState.Idle) unitView.SetState(UnitState.Idle);
                    currentState = UnitState.Idle;
                }
            }
        }

        private void OnDeath()
        {
            unitView.SetState(UnitState.Dead);
        }

        public virtual void OnProjectileHit(IProjectile projectile)
        {
            lastProjectile = projectile;
        }

        private void OnDestroy()
        {
            unitStatsMonitor.OnDeath -= OnDeath;
        }
    }
}