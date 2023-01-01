using UnityEngine;

namespace Diplom.Views.Base
{
    public class PlayerCameraView : MonoBehaviour
    {
        [SerializeField] private Vector3 _distance;
        [SerializeField] private Transform _target;

        private void Update()
        {
            transform.position = _target.position + _distance;
        }
    }
}