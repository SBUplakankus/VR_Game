using Attributes;
using UI.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Hosts
{
    public class BoundAttributePanelHost : MonoBehaviour
    {
        #region Fields
        
        [Header("UI Toolkit")]
        [SerializeField] private UIDocument uiDocument;
        [SerializeField] private StyleSheet styleSheet;
        
        [Header("Attribute")]
        [SerializeField] private IntAttribute attribute;
        
        private BoundAttributePanelView _boundAttributePanelView;
        
        #endregion
        
        #region Class Functions

        private void Generate()
        {
            _boundAttributePanelView = new BoundAttributePanelView(uiDocument.rootVisualElement,  styleSheet, attribute);
            attribute.Refresh();
        }
        
        #endregion
        
        #region Unity Functions
        
        private void OnEnable() => Generate();
        
        private void OnValidate()
        {
            if (Application.isPlaying) return;
            if (uiDocument == null || attribute == null) return;
            if (uiDocument.rootVisualElement == null) return;
            
            Generate();
        }
        
        #endregion
    }
}
