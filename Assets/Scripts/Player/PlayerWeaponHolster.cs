using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using Weapons;

namespace Player
{
    public class PlayerWeaponHolster : MonoBehaviour
    {
        [Header("Holsters")]
        [SerializeField] private XRSocketInteractor primaryHolster;
        [SerializeField] private XRSocketInteractor secondaryHolster;

        private XRBaseInteractable _primaryWeapon;
        private XRBaseInteractable _secondaryWeapon;

        private void SubscribeToHolsterEvents(XRSocketInteractor socket, bool isPrimaryHolster)
        {
            socket.selectEntered.AddListener((SelectEnterEventArgs args) =>
            {
                XRBaseInteractable weapon = args.interactableObject as XRBaseInteractable;
                if (weapon == null) return;

                if (isPrimaryHolster)
                {
                    _primaryWeapon = weapon;
                    Debug.Log($"[Holster] Primary Weapon Holstered: {weapon.name}");
                }
                else
                {
                    _secondaryWeapon = weapon;
                    Debug.Log($"[Holster] Secondary Weapon Holstered: {weapon.name}");
                }
            });

            socket.selectExited.AddListener((SelectExitEventArgs args) =>
            {
                XRBaseInteractable weapon = args.interactableObject as XRBaseInteractable;
                if (weapon == null) return;

                if (isPrimaryHolster && _primaryWeapon == weapon)
                {
                    _primaryWeapon = null;
                    Debug.Log("[Holster] Primary Weapon Removed");
                }
                else if (!isPrimaryHolster && _secondaryWeapon == weapon)
                {
                    _secondaryWeapon = null;
                    Debug.Log("[Holster] Secondary Weapon Removed");
                }
            });
        }

        private bool HasWeaponHolstered(bool isPrimary) => isPrimary ? _primaryWeapon != null : _secondaryWeapon != null;

        private XRBaseInteractable GetHolsteredWeapon(bool isPrimary) => isPrimary ? _primaryWeapon : _secondaryWeapon;

        private void Start()
        {
            SubscribeToHolsterEvents(primaryHolster, true);
            SubscribeToHolsterEvents(secondaryHolster, false);
        }
    }
}
