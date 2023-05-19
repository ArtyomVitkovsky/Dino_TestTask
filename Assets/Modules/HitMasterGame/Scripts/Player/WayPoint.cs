using System;
using UnityEngine;

namespace Modules.HitMasterGame.Scripts.Player
{
    [Serializable]
    public class WayPoint : MonoBehaviour
    {
        [SerializeField] private Transform point;
        [SerializeField] private float radius;
        [SerializeField] private bool isStopPoint;

        public Transform Point => point;

        public float Radius => radius;

        public bool IsStopPoint => isStopPoint;
    }
}