using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using Events;
using Factories;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Panels
{
    public class IntroPanel : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private UIDocument uiDocument;
        [SerializeField] private StyleSheet styleSheet;

        [SerializeField] private FloatEventChannel scaleChanged;
        [SerializeField] private VoidEventChannel spinClicked;
        
        private Button _spinButton;
        private Slider _scaleSlider;
        
        #endregion
        
        #region Class Functions

        private void OnSliderValueChanged(ChangeEvent<float> evt)
        {
            scaleChanged.Raise(evt.newValue);
        }

        private void OnSpinClicked()
        {
            spinClicked.Raise();
        }

        private void Generate()
        {
            UnsubscribeEvents();
            
            var root = uiDocument.rootVisualElement;
            root.Clear();
            
            if (!root.styleSheets.Contains(styleSheet))
                root.styleSheets.Add(styleSheet);
            
            var container = UIToolkitFactory.CreateContainer(GameConstants.ContainerStyle, GameConstants.PanelBodyStyle);
            
            var viewBox = UIToolkitFactory.CreateContainer(GameConstants.ViewBoxStyle, GameConstants.BorderedBoxStyle);
            container.Add(viewBox);
            
            var controlBox = UIToolkitFactory.CreateContainer(GameConstants.ControlBoxStyle, GameConstants.BorderedBoxStyle);
            container.Add(controlBox);

            _spinButton = UIToolkitFactory.CreateButton(GameConstants.SpinKey, OnSpinClicked);
            controlBox.Add(_spinButton);

            _scaleSlider = UIToolkitFactory.CreateSlider(0.5f, 2f, 1f);
            _scaleSlider.RegisterValueChangedCallback(OnSliderValueChanged);
            controlBox.Add(_scaleSlider);
            
            root.Add(container);
        }

        private void UnsubscribeEvents()
        {
            if (_spinButton != null)
                _spinButton.clicked -= OnSpinClicked;

            _scaleSlider?.UnregisterValueChangedCallback(OnSliderValueChanged);
        }
        
        #endregion
        
        #region Unity Functions
        
        private void OnEnable()
        {
            Generate();
        }
        
        private void OnValidate()
        {
            if (Application.isPlaying) return;
            if (uiDocument == null) return;
            if (uiDocument.rootVisualElement == null) return;
            
            Generate();
        }
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion
    }
}
