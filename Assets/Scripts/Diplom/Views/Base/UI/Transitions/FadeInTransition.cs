using System.Collections;
using UnityEngine;

namespace Diplom.Views.Base.UI.Transitions
{
    public class FadeInTransition : BaseTransition
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField, Range(0.5f, 100)] private float _speed = 1;
        
        public override IEnumerator Show()
        {
            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += 0.1f * _speed * Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }
}