using System;
using System.Collections;
using System.Diagnostics.Tracing;
using Constants;
using Events;
using UI.Factories;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Panels
{
    public enum ButtonType { PanelSelection, MenuSelection, Toggle }
    
    public abstract class BaseButtonPanel : MonoBehaviour
    {
        #region Fields

        [Header("UI Elements")]
        [SerializeField] protected UIDocument uiDocument;
        [SerializeField] protected StyleSheet styleSheet;

        [Header("Parameters")]
        [SerializeField] protected ButtonType buttonType;
        [SerializeField] protected string buttonTextKey;

        private Button _button;

        #endregion

        #region Class Functions

        protected string ButtonTypeKey()
        {
            return buttonType switch
            {
                ButtonType.PanelSelection => GameConstants.PanelSelectionButtonStyle,
                ButtonType.MenuSelection => GameConstants.MenuSelectionButtonStyle,
                ButtonType.Toggle => GameConstants.ToggleButtonStyle,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        protected abstract void OnButtonClicked();

        private void Generate()
        {
            UnsubscribeEvents();

            var root = uiDocument.rootVisualElement;

            if (!root.styleSheets.Contains(styleSheet))
                root.styleSheets.Add(styleSheet);

            var container = UIToolkitFactory.CreateContainer(GameConstants.ContainerStyle);
            
            _button = UIToolkitFactory.CreateButton(buttonTextKey, OnButtonClicked, ButtonTypeKey());
            container.Add(_button);
            
            root.Add(container);
            
        }

        private void UnsubscribeEvents()
        {
            if (_button != null)
                _button.clicked -= OnButtonClicked;
        }

        #endregion

        #region Unity Functions

        protected virtual void OnValidate()
        {
            if (Application.isPlaying) return;
            if (uiDocument == null) return;
            if (uiDocument.rootVisualElement == null) return;
            
            Generate();
        }
        
        protected virtual void OnEnable()
        {
            if (uiDocument == null || styleSheet == null)
            {
                Debug.LogError($"UI Document or Style Sheet missing on {gameObject.name}");
                return;
            }

            Generate();
        }

        protected virtual void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
    }

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
