using System;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.HitMasterGame.Scripts.Unit
{
    public class RagdollCollision : MonoBehaviour
    {
        [SerializeField] private Collider collider;
        
        public UnityAction<Collider, RagdollCollision> OnTriggerEnterEvent;

        public Collider Collider => collider;

        private void OnValidate()
        {
            if (collider == null) collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other, this);
        }
    }
}