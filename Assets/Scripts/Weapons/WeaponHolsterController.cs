using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Weapons
{
    public class WeaponHolsterController : MonoBehaviour
    {
        private XRGrabInteractable _grabInteractable;
        private Rigidbody _rigidbody;
        private Collider[] _colliders;
        private bool _isHolstered;

        private void OnGrabbed(SelectEnterEventArgs args)
        {
            Debug.Log($"[Weapon] Grabbed: {name}");
            _isHolstered = false;
            EnableHolsterPhysics(true);
        }

        private void OnReleased(SelectExitEventArgs args)
        {
            Debug.Log($"[Weapon] Released: {name}");
            if (_rigidbody.isKinematic)
                HolsterWeapon();
        }

        private void HolsterWeapon()
        {
            Debug.Log($"[Weapon] Holstered: {name}");
            _isHolstered = true;
            EnableHolsterPhysics(false);
        }

        private void EnableHolsterPhysics(bool toggle)
        {
            _rigidbody.isKinematic = !toggle;
            foreach (var col in _colliders)
                col.enabled = toggle;
        }

        private void Awake()
        {
            _grabInteractable = GetComponent<XRGrabInteractable>();
            _rigidbody = GetComponent<Rigidbody>();
            _colliders = GetComponentsInChildren<Collider>(true);
            _grabInteractable.selectEntered.AddListener(OnGrabbed);
            _grabInteractable.selectExited.AddListener(OnReleased);
        }
    }
}
