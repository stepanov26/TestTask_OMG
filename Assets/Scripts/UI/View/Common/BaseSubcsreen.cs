using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

namespace Jigsawgram.UI.View
{
    public abstract class BaseSubscreen : MonoBehaviour
    {
        [SerializeField] private float _animationDuration = 0.5f;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _closeButton;

        public event Action OnClosed;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }

        public virtual void Open()
        {
            
        }
        
        public virtual void Close()
        {
            StartCoroutine(FadeOutCoroutine());
        }

        private IEnumerator FadeOutCoroutine()
        {
            float startAlpha = _canvasGroup.alpha;
            float time = 0f;

            while (time < _animationDuration)
            {
                time += Time.deltaTime;
                float t = time / _animationDuration;
                _canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t);
                yield return null;
            }

            _canvasGroup.alpha = 0f;
            OnClosed?.Invoke();
        }
    }
}