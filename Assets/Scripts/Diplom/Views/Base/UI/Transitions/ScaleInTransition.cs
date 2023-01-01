using System.Collections;
using UnityEngine;

namespace Diplom.Views.Base.UI.Transitions
{
    public class ScaleInTransition : BaseTransition
    {
        [SerializeField, Range(1, 10)] private float _speed = 1;
        [SerializeField] private RectTransform _rect;
        
        public override IEnumerator Show()
        {
            while (_rect.localScale != Vector3.one)
            {
                _rect.localScale = Vector3.MoveTowards(
                    _rect.localScale, 
                    Vector3.one, 
                    Time.unscaledDeltaTime * _speed);
                
                yield return null;
            }
        }
    }
}