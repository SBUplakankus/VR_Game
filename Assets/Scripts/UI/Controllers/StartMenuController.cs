using Constants;
using Systems.Core;
using UI.Hosts;
using UI.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Controllers
{
    public class StartMenuController : MonoBehaviour
    {
        
        [SerializeField] private StartMenuPanelHost startMenuPanelHost;
        [SerializeField] private SettingsPanelHost settingsPanelHost;

        private bool _settingsActive;
        
                
        
        private void ToggleSettings()
        {
            _settingsActive = !_settingsActive;
            
            if(!_settingsActive)
                settingsPanelHost.Hide();
            else
                settingsPanelHost.Generate();
        }
        
        private void BindButtons()
        {
            startMenuPanelHost.SubscribeEvents();
            startMenuPanelHost.OnPlayClicked += HandlePlay;
            startMenuPanelHost.OnSettingsClicked += HandleSettings;
            startMenuPanelHost.OnControlsClicked += HandleControls;
            startMenuPanelHost.OnQuitClicked += HandleQuit;
        }

        private void UnbindButtons()
        {
            startMenuPanelHost.OnPlayClicked -= HandlePlay;
            startMenuPanelHost.OnSettingsClicked -= HandleSettings;
            startMenuPanelHost.OnControlsClicked -= HandleControls;
            startMenuPanelHost.OnQuitClicked -= HandleQuit;
        }
        
                
                
        private void HandlePlay()
        {
            BootstrapManager.Instance.LoadScene(GameConstants.Hub);
        }

        private void HandleSettings()
        {
            ToggleSettings();
        }

        private void HandleControls()
        {
            BootstrapManager.Instance.LoadScene(GameConstants.GoblinCampDay);
        }

        private void HandleQuit()
        {
            Application.Quit();
        }
        
                
        
        private void OnEnable()
        {
            startMenuPanelHost.Generate();
            BindButtons();
        }

        private void OnDisable()
        {
            UnbindButtons();
        }
        
                
    }
}