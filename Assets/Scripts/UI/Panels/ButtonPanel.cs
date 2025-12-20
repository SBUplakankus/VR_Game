using System;
using Constants;
using Factories;
using UnityEngine;
using UnityEngine.Localization;
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
                ButtonType.PanelSelection => GameConstants.PanelButtonStyle,
                ButtonType.MenuSelection => GameConstants.MenuButtonStyle,
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
            
            var buttonText = new LocalizedString(GameConstants.LocalTable,  buttonTextKey);
            _button = UIToolkitFactory.CreateButton(buttonText, OnButtonClicked, ButtonTypeKey());
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
}
