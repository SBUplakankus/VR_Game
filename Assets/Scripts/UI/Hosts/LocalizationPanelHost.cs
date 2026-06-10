using System;
using System.Collections.Generic;
using Events.Registries;
using UI.Views;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace UI.Hosts
{
    public class LocalizationPanelHost : MonoBehaviour
    {
                
        private Locale[] _availableLocales;
        private Action _unbindAll;

        
                
        public void BindPanel(LocalizationPanelView view)
        {
            DisposeView();

            _availableLocales = LocalizationSettings.AvailableLocales.Locales.ToArray();

            BindLanguages(view);
        }

        private void BindLanguages(LocalizationPanelView view)
        {
            var unbinders = new List<Action>();

            for (var i = 0; i < view.LanguageButtons.Count; i++)
            {
                var button = view.LanguageButtons[i];
                var locale = _availableLocales[i];

                button.clicked += OnClicked;
                unbinders.Add(() => button.clicked -= OnClicked);
                continue;

                void OnClicked()
                {
                    SetLocale(locale);
                }
            }

            _unbindAll = () =>
            {
                foreach (var unbind in unbinders)
                    unbind();
            };
        }

        private static void SetLocale(Locale locale)
        {
            SystemEvents.LocaleChangeRequested.Raise(locale);
        }
        
                
        
        public void DisposeView()
        {
            _unbindAll?.Invoke();
            _unbindAll = null;
        }

        private void OnDisable() => DisposeView();

            }
}
