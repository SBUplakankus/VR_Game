using Characters.Base;
using Characters.Enemies;
using Constants;
using Interfaces;
using UnityEngine;

namespace Weapons
{
    public class WeaponHitbox : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private XRWeaponBase weapon;

        [Header("Hit Detection")]
        [SerializeField] private float hitCooldown = GameConstants.InvincibilityDuration;

        private float _lastHitTime;
        private Collider _lastHitCollider;

        private void Reset() => weapon = GetComponentInParent<XRWeaponBase>();
        private void OnTriggerEnter(Collider other) => ProcessHit(other);

        private void OnTriggerStay(Collider other)
        {
            if (other != _lastHitCollider || Time.time >= _lastHitTime + hitCooldown)
                ProcessHit(other);
        }

        private void ProcessHit(Collider other)
        {
            if (!weapon || !weapon.IsActive || !weapon.CanAttack)
                return;

            if (weapon is MeleeXRWeapon meleeWeapon && !meleeWeapon.IsSwinging)
                return;

            if (!other.TryGetComponent<IDamageable>(out var target))
                return;

            var hitDirection = CalculateHitDirection(other.transform);
            var hitPoint = other.ClosestPoint(transform.position);
            var hitRotation = Quaternion.LookRotation(hitDirection);

            var damageMultiplier = weapon is MeleeXRWeapon melee ? melee.VelocityDamageMultiplier : 1f;

            weapon.ProcessHit(target, hitPoint, hitRotation, damageMultiplier);
            TriggerHitReaction(other, hitDirection);

            _lastHitTime = Time.time;
            _lastHitCollider = other;
        }

        private Vector3 CalculateHitDirection(Transform targetTransform)
        {
            var direction = (targetTransform.position - transform.position).normalized;

            if (weapon.TryGetComponent<Rigidbody>(out var rb) && rb.linearVelocity.sqrMagnitude > 0.1f)
                direction = rb.linearVelocity.normalized;

            return direction;
        }

        private void TriggerHitReaction(Collider other, Vector3 hitDirection)
        {
            var enemyAnimator = other.GetComponentInParent<EnemyAnimator>();
            if (enemyAnimator != null)
                enemyAnimator.PlayHitReaction(hitDirection);
        }
    }
}
