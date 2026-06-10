using UnityEngine;
using UnityEngine.Localization;

namespace Data.Settings
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Settings/Language")]
    public class LanguageSettingsConfig : ScriptableObject
    {
        
        [Header("Language Settings")]
        [SerializeField] private Locale language;

                
                
        public Locale Language
        {
            get => language;
            set => language = value;
        }
        
            }
}