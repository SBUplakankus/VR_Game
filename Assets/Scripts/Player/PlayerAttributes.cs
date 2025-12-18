using Attributes;
using Constants;
using Esper.ESave;
using Events;
using UnityEngine;

namespace Player
{
    public class PlayerAttributes  : MonoBehaviour
    {
        #region Fields
        
        [Header("Attributes")]
        [SerializeField] private IntAttribute playerGold;
        [SerializeField] private IntAttribute playerExperience;
        [SerializeField] private IntAttribute playerLevel;

        [Header("Events")] 
        [SerializeField] private VoidEventChannel onGameSaved;
        [SerializeField] private IntEventChannel onGoldChanged;
        [SerializeField] private IntEventChannel onExperienceChanged;
        [SerializeField] private IntEventChannel onLevelChanged;
        
        private SaveFile _saveFile;
        
        #endregion
        
        #region Properties
        
        public int Gold => playerGold.Value;
        public int Experience => playerExperience.Value;
        public int Level => playerLevel.Value;
        
        #endregion
        
        #region Class Functions
        
        private void SaveAttributes()
        {
            _saveFile.AddOrUpdateData(GameConstants.PlayerGoldKey, playerGold.Value);
            _saveFile.AddOrUpdateData(GameConstants.PlayerExperienceKey, playerExperience.Value);
            _saveFile.AddOrUpdateData(GameConstants.PlayerLevelKey, playerLevel.Value);
        }

        private void LoadAttributes()
        {
            playerGold.Value = _saveFile.GetData(GameConstants.PlayerGoldKey, playerGold.Value);
            playerExperience.Value = _saveFile.GetData(GameConstants.PlayerExperienceKey, playerGold.Value);
            playerLevel.Value = _saveFile.GetData(GameConstants.PlayerLevelKey, playerGold.Value);  
        }
        
        #endregion

        #region Event Handlers
        
        private void HandleGameSave() => SaveAttributes();
        private void HandleGoldChange(int amount) => playerGold.ModifyValue(amount);
        private void HandleExperienceChange(int amount) => playerExperience.ModifyValue(amount);
        private void HandleLevelChange(int amount) => playerLevel.ModifyValue(amount);
        
        private void SubscribeToEvents()
        {
            onGameSaved.Subscribe(HandleGameSave);
            onGoldChanged.Subscribe(HandleGoldChange);
            onExperienceChanged.Subscribe(HandleExperienceChange);
            onLevelChanged.Subscribe(HandleLevelChange);
        }

        private void UnsubscribeToEvents()
        {
            onGameSaved.Unsubscribe(HandleGameSave);
            onGoldChanged.Unsubscribe(HandleGoldChange);
            onExperienceChanged.Unsubscribe(HandleExperienceChange);
            onLevelChanged.Unsubscribe(HandleLevelChange);
        }

        #endregion
        
        #region Unity Functions

        private void Awake()
        {
            var setup = GetComponent<SaveFileSetup>();
            if (setup == null)
            {
                Debug.LogError($"No {nameof(SaveFileSetup)} found on {gameObject.name}");
                return;
            }
    
            _saveFile = setup.GetSaveFile();
            LoadAttributes();
        }

        private void OnEnable() => SubscribeToEvents();

        private void OnDisable() => UnsubscribeToEvents();
        
        #endregion
        
    }
}
