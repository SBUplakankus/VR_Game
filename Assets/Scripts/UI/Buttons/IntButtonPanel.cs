using Events;
using UI.Panels;
using UnityEngine;

namespace UI.Buttons
{
    public class IntButtonPanel : BaseButtonPanel
    {
        [Header("Event Channel")]
        [SerializeField] private IntEventChannel intEvent;
        [SerializeField] private int eventValue;
        
        protected override void OnButtonClicked()
        {
            if(intEvent == null)
                Debug.LogError($"Button {ButtonTypeKey()} not found on {gameObject.name}");
            else
                intEvent.Raise(eventValue);
        }
    }
}
