using Constants;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace UI
{
    public class WorldPanelEvents : MonoBehaviour
    {
         private UIDocument _uiDocument;
        private VisualElement _continueButtonElement; // Changed from Button
        private XRSimpleInteractable _xrInteractable; // New XR component reference

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            
            // Get the VisualElement that represents the button in UI
            _continueButtonElement = _uiDocument.rootVisualElement.Q<VisualElement>(GameConstants.ContinueButtonName);
            
            // Get or add the XR interactable component
            _xrInteractable = GetComponent<XRSimpleInteractable>();
            if (_xrInteractable == null)
                _xrInteractable = gameObject.AddComponent<XRSimpleInteractable>();
            
            // Subscribe to XR interaction events instead of ClickEvent
            _xrInteractable.selectEntered.AddListener(OnXRContinueButtonSelect);
            
            // Optional: Visual feedback on hover
            _xrInteractable.hoverEntered.AddListener(OnXRButtonHoverEnter);
            _xrInteractable.hoverExited.AddListener(OnXRButtonHoverExit);
        }

        private void OnDisable()
        {
            // Unsubscribe from XR events
            if (_xrInteractable == null) return;
            _xrInteractable.selectEntered.RemoveListener(OnXRContinueButtonSelect);
            _xrInteractable.hoverEntered.RemoveListener(OnXRButtonHoverEnter);
            _xrInteractable.hoverExited.RemoveListener(OnXRButtonHoverExit);
        }

        private void OnXRContinueButtonSelect(SelectEnterEventArgs args)
        {
            Debug.Log("OnXRContinueButtonSelect - Triggered by: " + args.interactorObject);
            // Add your continue logic here
        }

        // Optional: Add visual feedback methods
        private void OnXRButtonHoverEnter(HoverEnterEventArgs args)
        {
            Debug.Log("OnXRContinueButtonEnter - Triggered by: " + args.interactorObject);
            _continueButtonElement.AddToClassList("hovered");
        }

        private void OnXRButtonHoverExit(HoverExitEventArgs args)
        {
            Debug.Log("OnXRContinueButtonExit - Triggered by: " + args.interactorObject);
            _continueButtonElement.RemoveFromClassList("hovered");
        }
    }
}
