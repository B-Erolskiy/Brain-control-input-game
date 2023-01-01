using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diplom.Views.Base
{
  public class PointsMovingView : MonoBehaviour
  {
    [SerializeField] private List<Vector3> _movePoints = new List<Vector3>();
    [SerializeField] private float _speed;
    
    protected void Start()
    {
      StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
      int currentPointNumber = 0;
      while (true)
      {
        yield return StartCoroutine(MoveToLocalPoint(_movePoints[currentPointNumber]));
        currentPointNumber = currentPointNumber >= _movePoints.Count - 1 ? 0 : currentPointNumber + 1;
            
        yield return null;
      }
    }

    private IEnumerator MoveToLocalPoint(Vector3 point)
    {
      while (transform.localPosition != point)
      {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, point,
          _speed * Time.deltaTime);
        yield return null;
      }
    }
  }
}