using System.Collections;
using UnityEngine;

namespace Diplom.Views.Base.UI.Transitions
{
    public class FadeOutTransition : BaseTransition
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField, Range(0.5f, 100)] private float _speed = 1;
        
        public override IEnumerator Show()
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= 0.1f * _speed * Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }
}