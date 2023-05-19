using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.HitMasterGame.Scripts.Unit
{
    public class UnitBattleStats : MonoBehaviour, IStats
    {
        [SerializeField] private StatParameter<float> health;
        [SerializeField] private StatParameter<float> damage;
        
        public StatParameter<float> healthModifier;
        public StatParameter<float> damageModifier;

        public float Health => health.Value * healthModifier.Value;

        public float Damage => damage.Value * damageModifier.Value;

        public StatParameter<float> ClearHealth => health;

        public StatParameter<float> ClearDamage => damage;

        public void ReceiveDamage(float damage)
        {
            if (health.Value > 0)
            {
                health.Value -= damage;
            }
        }
    }
}