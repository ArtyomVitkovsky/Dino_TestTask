using UnityEngine;
using UnityEngine.Events;

namespace Modules.HitMasterGame.Scripts.Player
{
    public class Pathway : MonoBehaviour
    {
        [SerializeField] private WayPoint[] wayPoints;

        private int wayPointIndex;

        public UnityAction OnLastPointReached;

        public WayPoint currentPoint => wayPoints[wayPointIndex];

        public WayPoint GetNextPoint()
        {
            wayPointIndex++;
            if (wayPointIndex >= wayPoints.Length)
            {
                OnLastPointReached?.Invoke();
                return null;
            }

            return wayPoints[wayPointIndex];
        }
    }
}