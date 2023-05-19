using UnityEngine;

namespace Modules.HitMasterGame.Scripts.Unit
{
    public class UnitMovementStats : MonoBehaviour, IStats
    {
        [SerializeField] private float speed;

        public float speedModifier;

        public float Speed => speed * speedModifier;

    }
}