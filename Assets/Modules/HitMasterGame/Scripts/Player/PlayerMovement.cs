using System;
using Modules.Main.Scripts;
using Modules.Main.Scripts.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Zenject;

namespace Modules.HitMasterGame.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        private Pathway pathway;

        private Transform lookTarget;
        
        public UnityAction<WayPoint> OnWayPointReached;
        
        private Unit.Player.Player player;
        private SceneLoader sceneLoader;
        private UIManager uiManager;
        [Inject]
        private void Construct(Pathway pathway, Unit.Player.Player player, SceneLoader sceneLoader, UIManager uiManager)
        {
            this.player = player;
            
            this.sceneLoader = sceneLoader;

            this.uiManager = uiManager;
            this.uiManager.GameScreen.StartButton.onClick.AddListener(StartMovement);
            
            this.pathway = pathway;
            this.pathway.OnLastPointReached += sceneLoader.ReloadGameScene;
        }

        public WayPoint GetCurrentWayPoint()
        {
            return pathway.currentPoint;
        }
        private void StartMovement()
        {
            navMeshAgent.destination = pathway.currentPoint.Point.position;
            navMeshAgent.speed = player.MovementStats.Speed;
        }

        private void Update()
        {
            if (GameSettings.IS_PAUSED) navMeshAgent.speed = 0;

            if (Vector3.Distance(transform.position, pathway.currentPoint.Point.position) <=
                pathway.currentPoint.Radius)
            {
                OnWayPointReached?.Invoke(pathway.currentPoint);
                if (!pathway.currentPoint.IsStopPoint)
                {
                    SetNextPointDestination();
                }
                else
                {
                    LookAt(lookTarget);
                }
            }
        }

        public void SetNextPointDestination()
        {
            var nextPoint = pathway.GetNextPoint();
            if (nextPoint != null)
            {
                navMeshAgent.destination = nextPoint.Point.position;
            }
        }

        public void LookAt(Transform target)
        {
            if(target == null) return;
            
            var heading = target.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;

            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = 
                Quaternion.RotateTowards(
                transform.rotation, 
                targetRotation, 
                navMeshAgent.angularSpeed / 10f * Time.deltaTime);
        }

        public void SetLookTarget(Transform target)
        {
            lookTarget = target;
        }
    }
}