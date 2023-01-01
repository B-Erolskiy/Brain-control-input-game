using System.Collections;
using UnityEngine;

namespace Diplom.Views.Base.UI.Transitions
{
    public abstract class BaseTransition : MonoBehaviour
    {
        public abstract IEnumerator Show();
    }
}