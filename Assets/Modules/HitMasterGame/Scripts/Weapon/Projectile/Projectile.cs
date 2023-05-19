using System;
using System.Collections;
using Modules.HitMasterGame.Scripts.Unit;
using Modules.HitMasterGame.Scripts.Weapon.Projectile.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.HitMasterGame.Scripts.Weapon.Projectile
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField] protected Rigidbody _rigidbody;
        [SerializeField] protected float speed; 
        [SerializeField] protected float mass; 
        [SerializeField] protected float damage;
        [SerializeField] protected float lifeTime;
        protected UnitBattleStats damagedUnit;

        private float moveDuration;

        private Vector3 target;
        private Transform parent;
        
        private Coroutine disableCoroutine;

        private void Awake()
        {
            parent = transform.parent;
        }
        
        private void OnEnable()
        {
            transform.SetParent(null);
            moveDuration = 0f;
        }

        private void FixedUpdate()
        {
            Move(Time.fixedDeltaTime);
        }

        private void Move(float deltaTime)
        {
            _rigidbody.MovePosition(transform.position + transform.forward * deltaTime * speed);
        }

        public void Damage()
        {
            damagedUnit.ReceiveDamage(damage);
        }

        public void SetTargetDestination(Vector3 target)
        {
            this.target = target;
            
            gameObject.SetActive(true);
            // _rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
            disableCoroutine = StartCoroutine(DisableCoroutine(lifeTime));
        }

        public float GetDamage()
        {
            return damage;
        }

        public float GetHitForce()
        {
            return mass * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player")) return;

            transform.SetParent(parent);
            gameObject.SetActive(false);
        }

        protected IEnumerator DisableCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            transform.SetParent(parent);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            if(disableCoroutine != null) StopCoroutine(disableCoroutine);
            
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = false;
        }
    }
}