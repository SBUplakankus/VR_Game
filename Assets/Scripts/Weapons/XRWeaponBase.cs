using Characters.Base;
using Data.Weapons;
using Interfaces;
using Pooling;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Weapons
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public abstract class XRWeaponBase : MonoBehaviour
    {
        [Header("Weapon Data")]
        [SerializeField] protected WeaponData data;

        [Header("Haptic Feedback")]
        [SerializeField] protected bool enableHaptics = true;

        private XRGrabInteractable _grab;
        private XRBaseInteractor _currentInteractor;
        protected bool IsHeld;

        private float _lastAttackTime;

        public WeaponData Data => data;
        public bool IsActive => IsHeld;
        public bool CanAttack => Time.time >= _lastAttackTime + data.AttackCooldown;

        protected virtual void OnGrab(SelectEnterEventArgs args)
        {
            IsHeld = true;
            _currentInteractor = args.interactorObject as XRBaseInteractor;
            OnEquipped();
        }

        protected virtual void OnRelease(SelectExitEventArgs args)
        {
            IsHeld = false;
            _currentInteractor = null;
            OnUnequipped();
        }

        private void RegisterAttack() => _lastAttackTime = Time.time;

        public void ProcessHit(IDamageable target, Vector3 hitPoint, Quaternion hitRotation, float damageMultiplier = 1f)
        {
            if (!CanAttack) return;

            RegisterAttack();

            var finalDamage = Mathf.RoundToInt(data.TotalDamage * damageMultiplier);
            finalDamage = Mathf.Max(1, finalDamage);

            target.TakeDamage(finalDamage);

            if (data.HitVFX != null)
                GamePoolManager.Instance?.GetParticlePrefab(data.HitVFX, hitPoint, hitRotation);

            if (data.HitSfx != null)
                GamePoolManager.Instance?.GetWorldAudioPrefab(data.HitSfx, hitPoint);

            TriggerHapticFeedback();
        }

        protected void TriggerHapticFeedback()
        {
            if (!enableHaptics || data == null || _currentInteractor == null)
                return;

            if (_currentInteractor.TryGetComponent<XRBaseInputInteractor>(out var inputInteractor))
                inputInteractor.SendHapticImpulse(data.HapticStrength, data.HapticDuration);
        }

        public abstract void PrimaryAction();
        public abstract void SecondaryAction();

        protected virtual void OnEquipped() { }
        protected virtual void OnUnequipped() { }

        protected virtual void Awake()
        {
            _grab = GetComponent<XRGrabInteractable>();
            _grab.selectEntered.AddListener(OnGrab);
            _grab.selectExited.AddListener(OnRelease);
        }

        protected virtual void OnDestroy()
        {
            if (_grab != null)
            {
                _grab.selectEntered.RemoveListener(OnGrab);
                _grab.selectExited.RemoveListener(OnRelease);
            }
        }
    }
}
