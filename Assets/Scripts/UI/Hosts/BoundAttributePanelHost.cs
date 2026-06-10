using Attributes;
using UI.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Hosts
{
    public class BoundAttributePanelHost : BasePanelHost
    {
                
        [Header("Attribute")]
        [SerializeField] private IntAttribute attribute;
        
        private BoundAttributePanelView _boundAttributePanelView;
        
                
        
        public override void Generate()
        {
            Dispose();
            _boundAttributePanelView = new BoundAttributePanelView(uiDocument.rootVisualElement,  styleSheet, attribute);
            attribute.Refresh();
        }

        protected override void Dispose()
        {
            _boundAttributePanelView?.Dispose();
            _boundAttributePanelView = null;
        }

                
                
        private void OnEnable() => Generate();
        
            }
}
