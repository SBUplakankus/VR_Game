using Events;
using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class VoidButtonPanel : BaseButtonPanel
    {
        [Header("Event Channel")]
        [SerializeField] private VoidEventChannel voidEvent;
            
        protected override void OnButtonClicked()
        {
            if (voidEvent == null)
                Debug.LogError($"Button {ButtonTypeKey()} not found on {gameObject.name}");
            else
                voidEvent.Raise();
        }
    }
}
