using System;
using Attributes;
using UI.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Hosts
{
    public class VideoSettingsPanelHost : MonoBehaviour
    {
        
        [Header("Settings")] 
        [SerializeField] private IntAttribute qualitySetting;
        [SerializeField] private IntAttribute aliasingSetting;
        [SerializeField] private IntAttribute renderScaleSetting;
        
        private Action _unbindAll;

        
        
        private static Action BindDropdown(DropdownField field, IntAttribute setting)
        {
            if (field == null || setting == null) return null;

            // Initial sync
            field.index = setting.Value;

            field.RegisterValueChangedCallback(OnDropdownChanged);

            setting.OnValueChanged += OnAttributeChanged;

            // Unbind action
            return () =>
            {
                field.UnregisterValueChangedCallback(OnDropdownChanged);
                setting.OnValueChanged -= OnAttributeChanged;
            };

            // Attribute → UI
            void OnAttributeChanged(int value)
            {
                field.SetValueWithoutNotify(field.choices[value]);
            }

            // UI → Attribute
            void OnDropdownChanged(ChangeEvent<string> evt)
            {
                setting.Value = field.index;
            }
        }
        
        public void BindPanel(VideoSettingsPanelView view)
        {
            DisposeView();
            
            _unbindAll += BindDropdown(view.Quality, qualitySetting);
            _unbindAll += BindDropdown(view.AntiAliasing, aliasingSetting);
            _unbindAll += BindDropdown(view.RenderScale, renderScaleSetting);
        }
        
        public void DisposeView()
        {
            _unbindAll?.Invoke();
            _unbindAll = null;
        }

        private void OnDisable() => DisposeView();

            }
}
