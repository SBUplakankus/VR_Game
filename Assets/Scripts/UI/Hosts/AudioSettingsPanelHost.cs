using System;
using Attributes;
using UI.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Hosts
{
    public class AudioSettingsPanelHost : MonoBehaviour
    {
        #region Fields

        [Header("UI Toolkit")] 
        [SerializeField] private UIDocument uiDocument;
        [SerializeField] private StyleSheet styleSheet;
        
        [Header("Audio Settings")]
        [SerializeField] private FloatAttribute masterVolume;
        [SerializeField] private FloatAttribute musicVolume;
        [SerializeField] private FloatAttribute sfxVolume;
        [SerializeField] private FloatAttribute ambienceVolume;
        [SerializeField] private FloatAttribute uiVolume;

        private Action _unbindAll;

        #endregion

        #region View

        private AudioSettingsPanelView _view;

        #endregion

        #region Private Methods

        private static Action BindSlider(Slider slider, FloatAttribute attribute)
        {
            if (slider == null || attribute == null) return null;

            slider.SetValueWithoutNotify(attribute.Value);

            EventCallback<ChangeEvent<float>> sliderCallback =
                e => attribute.Value = e.newValue;

            slider.RegisterValueChangedCallback(sliderCallback);
            attribute.OnValueChanged += slider.SetValueWithoutNotify;

            return () =>
            {
                slider.UnregisterValueChangedCallback(sliderCallback);
                attribute.OnValueChanged -= slider.SetValueWithoutNotify;
            };
        }
        
        private void Generate()
        {
            DisposeView();

            _view = new AudioSettingsPanelView(
                uiDocument.rootVisualElement,
                styleSheet
            );
            
            _unbindAll = () => { };

            _unbindAll += BindSlider(_view.MasterVolume, masterVolume);
            _unbindAll += BindSlider(_view.MusicVolume, musicVolume);
            _unbindAll += BindSlider(_view.AmbienceVolume, ambienceVolume);
            _unbindAll += BindSlider(_view.SfxVolume, sfxVolume);
            _unbindAll += BindSlider(_view.UIVolume, uiVolume);
        }

        private void DisposeView()
        {
            _unbindAll?.Invoke();
            _unbindAll = null;
            
            _view?.Dispose();
            _view = null;
        }

        #endregion

        #region Unity Lifecycle

        private void OnEnable() => Generate();

        private void OnDisable() => DisposeView();

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Application.isPlaying) return;
            if (uiDocument == null) return;
            if (uiDocument.rootVisualElement == null) return;

            Generate();
        }
#endif

        #endregion
    }
}
