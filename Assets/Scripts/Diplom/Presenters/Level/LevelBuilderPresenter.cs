using System.Collections.Generic;
using UnityEngine;

namespace Diplom.Presenters.Level
{
  public class LevelBuilderPresenter : MonoBehaviour, ILevelBuilderPresenter
  {
    [SerializeField] private List<Transform> _levelBlocks;
    [SerializeField] private float _levelBlockLength = 12f;
    
    private int _currentBlockNumber;
    private float _currentLength;

    private void Start()
    {
      _currentLength = (_levelBlocks.Count - 2) * _levelBlockLength;
    }

    public void FinishLevel()
    {
      _currentLength += _levelBlockLength;
      var currentPosition = _levelBlocks[_currentBlockNumber].position;
      _levelBlocks[_currentBlockNumber].position = new Vector3(currentPosition.x, currentPosition.y,
        _currentLength);

      _currentBlockNumber++;
      if (_currentBlockNumber >= _levelBlocks.Count)
      {
        _currentBlockNumber = 0;
      }
    }
  }
}