using System;
using Constants;
using Factories;
using UnityEngine.Localization;
using UnityEngine.UIElements;

namespace UI.Views
{
    public class StartMenuPanelView : IDisposable
    {
        #region Fields

        private VisualElement _container;
        public event Action OnPlayClicked;
        public event Action OnControlsClicked;
        public event Action OnAudioSettingsClicked;
        public event Action OnVideoSettingsClicked;
        public event Action OnQuitClicked;

        #endregion

        #region Constructors

        public StartMenuPanelView(VisualElement root, StyleSheet styleSheet)
        {
            if (!root.styleSheets.Contains(styleSheet))
                root.styleSheets.Add(styleSheet);

            GenerateUI(root);
        }

        #endregion

        #region Methods

        private void GenerateUI(VisualElement root)
        {
            _container = UIToolkitFactory.CreateContainer(UIToolkitStyles.Container, UIToolkitStyles.PanelBody);
            
            var buttonContainer = UIToolkitFactory.CreateContainer(UIToolkitStyles.Container, UIToolkitStyles.PanelBody);
            
            var playButton = UIToolkitFactory.CreateButton(
                LocalizationFactory.CreateString(LocalizationKeys.Play), 
                OnPlayClicked,
                UIToolkitStyles.MenuButton);
            
            buttonContainer.Add(playButton);
            
            var audioSettingsButton = UIToolkitFactory.CreateButton(
                LocalizationFactory.CreateString(LocalizationKeys.AudioSettings),
                OnAudioSettingsClicked,
                UIToolkitStyles.MenuButton);
            
            buttonContainer.Add(audioSettingsButton);
            
            var videoSettingsButton = UIToolkitFactory.CreateButton(
                LocalizationFactory.CreateString(LocalizationKeys.VideoSettings),
                OnVideoSettingsClicked,
                UIToolkitStyles.MenuButton);
            
            buttonContainer.Add(videoSettingsButton);

            root.Add(_container);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            if (_container == null) return;

            _container.RemoveFromHierarchy();
            _container = null;
        }

        #endregion
    }
}
