using System;
using System.Collections.Generic;
using Modules.HitMasterGame.Scripts.Weapon.Projectile.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Modules.HitMasterGame.Scripts.Unit
{
    public class UnitView : MonoBehaviour
    {
        [SerializeField] protected RagdollSystem ragdollSystem;
        [SerializeField] protected AnimationController animator;
        
        private List<Hit> lastHits;

        public UnityAction<IProjectile> OnProjectileHit;

        public RagdollSystem RagdollSystem => ragdollSystem;

        private void Start()
        {
            ragdollSystem.OnTriggerEnterEvent += OnRagdollTriggerEnterEvent;
        }

        private void OnRagdollTriggerEnterEvent(Collider collider, RagdollNode ragdollNode)
        {  
            if (collider.TryGetComponent(out IProjectile projectile))
            {
                lastHits ??= new List<Hit>();
                
                lastHits.Add(new Hit
                {
                    hitedNode = ragdollNode, 
                    hitObjectPosition = collider.transform.position, 
                    force = projectile.GetHitForce()
                });
                
                OnProjectileHit?.Invoke(projectile);
            }
        }

        public void SetState(UnitState state)
        {
            switch (state)
            {
                case UnitState.Idle:
                {
                    animator.SetTrigger(AnimationActionType.Idle);
                    break;
                }
                case UnitState.Walking:
                {
                    animator.SetTrigger(AnimationActionType.Action);
                    break;
                }
                case UnitState.Dead:
                {
                    DisableAnimator();
                    EnableRagdoll();
                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        private void DisableAnimator()
        {
            animator.SetActive(false);
        }
        
        public void EnableAnimator()
        {
            animator.enabled = true;
        }
        
        public void DisableRagdoll()
        {
            ragdollSystem.Disable();
        }
        
        private void EnableRagdoll()
        {
            ragdollSystem.Enable();
            AddHitForce();
        }
        
        private void AddHitForce()
        {
            foreach (var hit in lastHits)
            {
                var hitedNode = hit.hitedNode;
                var heading = hitedNode.transform.position - hit.hitObjectPosition;
                var distance = heading.magnitude;
                var direction = heading / distance;
                hitedNode.Rigidbody.AddForce(direction * hit.force, ForceMode.Impulse);
            }
        }
    }
}