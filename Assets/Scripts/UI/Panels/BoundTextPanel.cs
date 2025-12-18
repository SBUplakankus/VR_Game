using Attributes;
using Constants;
using Events;
using Factories;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Panels
{
    public class BoundTextPanel : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private UIDocument uiDocument;
        [SerializeField] private StyleSheet styleSheet;
        
        [SerializeField] private IntAttribute attribute;
        
        private Label _textLabel;
        
        #endregion
        
        #region Class Functions

        private void Generate()
        {
            var root = uiDocument.rootVisualElement;
            root.Clear();
            
            if (!root.styleSheets.Contains(styleSheet))
                root.styleSheets.Add(styleSheet);
            
            var container = UIToolkitFactory.CreateContainer(GameConstants.ContainerStyle, GameConstants.PanelBodyStyle);

            var header = UIToolkitFactory.CreateLabel(attribute.name, GameConstants.HeaderStyle);
            container.Add(header);
            
            var stat =  UIToolkitFactory.CreateBoundLabel(attribute, nameof(attribute.Value), GameConstants.StatStyle);
            container.Add(stat);
            
            attribute.Notify(nameof(attribute.Value));
            
            root.Add(container);
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
            if (uiDocument == null || attribute == null) return;
            if (uiDocument.rootVisualElement == null) return;
            
            
            Generate();
        }
        
        #endregion
    }
}
