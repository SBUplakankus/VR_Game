using Constants;
using UnityEngine;

namespace Weapons
{
    public class MeleeXRWeapon : XRWeaponBase
    {
        [Header("Melee Settings")]
        [SerializeField] private float minSwingVelocity = GameConstants.MinSwingVelocity;
        [SerializeField] private float maxSwingVelocity = GameConstants.MaxSwingVelocity;

        private Rigidbody _rb;
        private Vector3 _previousPosition;
        private float _currentVelocity;

        public float SwingVelocity => _currentVelocity;
        public bool IsSwinging => _currentVelocity >= minSwingVelocity;

        public float VelocityDamageMultiplier
        {
            get
            {
                if (_currentVelocity < minSwingVelocity)
                    return 0f;

                var normalizedVelocity = Mathf.InverseLerp(minSwingVelocity, maxSwingVelocity, _currentVelocity);
                return Mathf.Lerp(
                    GameConstants.MinVelocityDamageMultiplier,
                    GameConstants.MaxVelocityDamageMultiplier,
                    normalizedVelocity
                );
            }
        }

        public override void PrimaryAction() { }

        public override void SecondaryAction() { }

        protected override void OnEquipped()
        {
            base.OnEquipped();
            _previousPosition = transform.position;
            _currentVelocity = 0f;
        }

        protected override void OnUnequipped()
        {
            base.OnUnequipped();
            _currentVelocity = 0f;
        }

        protected override void Awake()
        {
            base.Awake();
            _rb = GetComponent<Rigidbody>();
            _previousPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if (!IsHeld)
            {
                _currentVelocity = 0f;
                return;
            }

            var currentPosition = transform.position;
            _currentVelocity = (currentPosition - _previousPosition).magnitude / Time.fixedDeltaTime;
            _previousPosition = currentPosition;
        }
    }
}
