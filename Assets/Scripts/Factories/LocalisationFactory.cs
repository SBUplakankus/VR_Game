using Constants;
using UnityEngine;
using UnityEngine.Localization;

namespace Factories
{
    public static class LocalizationFactory
    {
        public static LocalizedString CreateString(string key)
        {
#if UNITY_EDITOR
            if (string.IsNullOrEmpty(key))
                Debug.LogWarning("Localization key is null or empty");
#endif
            return new LocalizedString(LocalizationKeys.MainTable, key);
        }
    }
}