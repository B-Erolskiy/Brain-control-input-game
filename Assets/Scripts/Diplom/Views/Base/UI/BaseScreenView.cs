using System.Collections;
using Diplom.Views.Base.UI.Transitions;
using UnityEngine;

namespace Diplom.Views.Base.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseScreenView : MonoBehaviour
    {
        [Header("Transitions")]
        [SerializeField] private BaseTransition _inTransition;
        [SerializeField] private BaseTransition _outTransition;

        private CanvasGroup _canvasGroup;
        private CanvasGroup GetCanvasGroup
        {
            get
            {
                _canvasGroup = _canvasGroup == null ? GetComponent<CanvasGroup>() : _canvasGroup;
                return _canvasGroup;
            }
        }

        public bool IsActive { get; private set; } = true;

        protected void OnScreenActiveStateChange(bool newIsActiveValue)
        {
            if (newIsActiveValue)
            {
                gameObject.SetActive(true);
                StartCoroutine(Show());
        
            }
            else if (gameObject.activeSelf)
            {
                StartCoroutine(Hide());
            }
        }
        
        public IEnumerator Show()
        {
            IsActive = true;
            gameObject.SetActive(true);
            GetCanvasGroup.interactable = false;
            yield return StartCoroutine(_inTransition.Show());
            GetCanvasGroup.interactable = true;
        }

        public IEnumerator Hide()
        {
            GetCanvasGroup.interactable = false;
            if (gameObject.activeSelf)
            {
                yield return StartCoroutine(_outTransition.Show());
            }
            ForceHide();
        }

        public void ForceHide()
        {
            gameObject.SetActive(false);
            IsActive = false;
        }
    }
}