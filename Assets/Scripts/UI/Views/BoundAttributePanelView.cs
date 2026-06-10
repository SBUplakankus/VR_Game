using System;
using Attributes;
using Constants;
using Factories;
using UnityEngine.Localization;
using UnityEngine.UIElements;

namespace UI.Views
{
    public class BoundAttributePanelView : IDisposable
    {
        
        private VisualElement _container;
        
                
        
        public BoundAttributePanelView(VisualElement root, StyleSheet styleSheet, IntAttribute attribute)
        {
            if(!root.styleSheets.Contains(styleSheet))
                root.styleSheets.Add(styleSheet);
            
            GenerateUI(root, attribute);
        }
        
                
                
        private void GenerateUI(VisualElement root, IntAttribute attribute)
        {
            if (_container != null)
                Dispose();
            
            _container = UIToolkitFactory.CreateContainer(UIToolkitStyles.Container, UIToolkitStyles.PanelBody);

            var header = UIToolkitFactory.CreateLabel(attribute.AttributeName, UIToolkitStyles.AttributePanelHeader);
            _container.Add(header);
            
            var stat =  UIToolkitFactory.CreateBoundLabel(attribute, nameof(attribute.Value), UIToolkitStyles.Stat);
            _container.Add(stat);
            
            root.Add(_container);
        }
        
        public void Dispose()
        {
            if(_container == null) return;
            _container.Clear();
            _container.RemoveFromHierarchy();
            _container = null;
        }
        
            }
}