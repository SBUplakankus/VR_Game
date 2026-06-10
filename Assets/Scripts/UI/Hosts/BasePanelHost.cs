using UI.Extensions;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Hosts
{
    public abstract class BasePanelHost : MonoBehaviour
    {
        [Header("UI Toolkit")]
        [SerializeField] protected UIDocument uiDocument;
        [SerializeField] protected StyleSheet styleSheet;

        protected VisualElement ContentRoot;
        private ITweenable[] _tweenables;

        public void Show()
        {
            if(_tweenables == null) return;
            foreach (var tween in _tweenables)
                tween?.Show();
        }

        public void Hide()
        {
            if(_tweenables == null) return;
            foreach (var tween in _tweenables)
                tween?.Hide();
        }

        public abstract void Generate();
        protected abstract void Dispose();

        private void Awake() => _tweenables = GetComponents<ITweenable>();
        private void OnDisable() => Dispose();

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Application.isPlaying) return;
            if (uiDocument == null) return;
            if (uiDocument.rootVisualElement == null) return;

            Generate();
        }
#endif
    }
}
