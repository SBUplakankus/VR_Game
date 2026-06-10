using PrimeTween;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Extensions
{
    public class TweenAlpha : MonoBehaviour, ITweenable
    {
        [Header("Display Settings")]
        [SerializeField] private float duration = 0.25f;
        [SerializeField] private bool startHidden;

        [Header("Tween Settings")]
        [SerializeField] private Ease showEase = Ease.Linear;
        [SerializeField] private Ease hideEase = Ease.Linear;

        private const float ShowAlpha = 1f;
        private const float HideAlpha = 0f;

        private UIDocument _uiDocument;
        private VisualElement _root;
        private Tween _currentTween;

        public bool IsTweening => _currentTween.isAlive;

        public void Show()
        {
            StopTween();
            _currentTween = Tween.Custom(
                startValue: _root.resolvedStyle.opacity,
                endValue: ShowAlpha,
                duration: duration,
                onValueChange: SetAlpha,
                ease: showEase
            );
        }

        public void Hide()
        {
            StopTween();
            _currentTween = Tween.Custom(
                startValue: _root.resolvedStyle.opacity,
                endValue: HideAlpha,
                duration: duration,
                onValueChange: SetAlpha,
                ease: hideEase
            );
        }

        public void StopTween()
        {
            if (_currentTween.isAlive)
                _currentTween.Complete();
        }

        private void SetAlpha(float value) => _root.style.opacity = value;

        private void Awake() => _uiDocument = GetComponent<UIDocument>();

        private void OnEnable()
        {
            _root = _uiDocument.rootVisualElement;
            var initialAlpha = startHidden ? HideAlpha : ShowAlpha;
            SetAlpha(initialAlpha);
        }
    }
}
