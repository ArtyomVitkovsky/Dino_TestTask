using UnityEngine;
using UnityEngine.Events;

namespace Modules.HitMasterGame.Scripts.Unit
{
    public class UnitStatsMonitor : MonoBehaviour
    {
        private bool isDead;
        public UnityAction OnDeath;

        public bool IsDead => isDead;

        public void CheckHealth(float health)
        {
            if (health <= 0)
            {
                isDead = true;
                OnDeath?.Invoke();
            }
        }
    }
}