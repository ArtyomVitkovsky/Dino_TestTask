using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Modules.HitMasterGame.Scripts.Unit
{
    [Serializable]
    public class RagdollNode : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private RagdollCollision collision;
        
        public UnityAction<Collider, RagdollNode> OnTriggerEnterEvent;

        public Rigidbody Rigidbody => rigidbody;
        
        public RagdollCollision Collision => collision;

        public void Setup(Rigidbody rigidbody, RagdollCollision collision)
        {
            this.rigidbody = rigidbody;
            this.collision = collision;
        }

        private void Start()
        {
            collision.OnTriggerEnterEvent += OnCollisionTriggerEnter;
        }

        private void OnCollisionTriggerEnter(Collider collider, RagdollCollision ragdollCollision)
        {
            OnTriggerEnterEvent?.Invoke(collider, this);
        }
    }
}