using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.HitMasterGame.Scripts.Unit
{
    public class RagdollSystem : MonoBehaviour
    {
        [SerializeField] private List<RagdollNode> ragdollNodes;

        public UnityAction<Collider, RagdollNode> OnTriggerEnterEvent;

        private void OnValidate()
        {
            ragdollNodes ??= new List<RagdollNode>();

            if (ragdollNodes.Count == 0)
            {
                var childRb = GetComponentsInChildren<Rigidbody>();

                foreach (var rigidbody in childRb)
                {
                    var nodeGO = rigidbody.gameObject;
                    if (!nodeGO.TryGetComponent(out RagdollNode node))
                    {
                        node = nodeGO.AddComponent<RagdollNode>();
                    }
                    if (!nodeGO.TryGetComponent(out RagdollCollision collision))
                    {
                        collision = nodeGO.AddComponent<RagdollCollision>();
                    }
                    
                    node.Setup(rigidbody, collision);
                    
                    ragdollNodes.Add(node);
                }
            }
        }

        private void Start()
        {
            foreach (var node in ragdollNodes)
            {
                node.OnTriggerEnterEvent += OnCollisionTriggerEnter;
            }
        }

        private void OnCollisionTriggerEnter(Collider collider, RagdollNode ragdollNode)
        {
            OnTriggerEnterEvent?.Invoke(collider, ragdollNode);
        }

        public void Enable()
        {
            SetActive(true);
        }
        
        public void Disable()
        {
            SetActive(false);
        }
        
        private void SetActive(bool isActive)
        {
            foreach (var rigidbody in ragdollNodes)
            {
                rigidbody.Rigidbody.isKinematic = !isActive;
            }
        }
    }
}
