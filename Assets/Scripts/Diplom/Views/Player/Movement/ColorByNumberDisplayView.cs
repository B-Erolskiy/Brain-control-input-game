using System;
using UnityEngine;
using UnityEngine.UI;

namespace Diplom.Views.Player.Movement
{
  public class ColorByNumberDisplayView : MonoBehaviour
  {
    [Header("Check rules")]
    [SerializeField] private float _checkNumber;
    [SerializeField] private CheckType _checkType;
    [SerializeField] private float _tolerance = 0.01f;
    
    [Header("Colors")]
    [SerializeField] private Color _successCheckColor;
    [SerializeField] private Color _failedCheckColor;

    [Header("Color display")]
    [SerializeField] private Graphic _graphic;

    public void SetNumber(float number, float checkNumber)
    {
      bool checkResult;

      switch (_checkType)
      {
        case CheckType.More:
          checkResult = number > checkNumber;
          break;
        case CheckType.Less:
          checkResult = number < checkNumber;
          break;
        case CheckType.Equal:
          checkResult = Math.Abs(number - checkNumber) < _tolerance;
          break;
        case CheckType.MoreOrEqual:
          checkResult = number >= checkNumber;
          break;
        case CheckType.LessOrEqual:
          checkResult = number <= checkNumber;
          break;
        default:
          checkResult = false;
          break;
      }

      _graphic.color = checkResult ? _successCheckColor : _failedCheckColor;
    }

    public void SetNumber(float number)
    {
      SetNumber(number, _checkNumber);
    }
    
    public enum CheckType : byte
    {
      Equal = 0,
      More = 1,
      Less = 2,
      MoreOrEqual = 3,
      LessOrEqual = 4
    }
  }
}