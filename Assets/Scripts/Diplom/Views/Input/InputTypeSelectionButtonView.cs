using System;
using Diplom.Entities.Input;
using Diplom.Presenters.Input;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.Input
{
  [RequireComponent(typeof(Button))]
  public class InputTypeSelectionButtonView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private InputType _selectInputType;
    
    private Button _button;
    private IInputPresenter _presenter;

    [Inject]
    private void Construct(IInputPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _button = GetComponent<Button>();
      _button.OnClickAsObservable().Subscribe(_ => SelectInputType()).AddTo(_button);
      _presenter.InputType.Subscribe(UpdateInputType).AddTo(this);
    }

    private void UpdateInputType(InputType newInputType)
    {
      var isEnabledCurrentType = newInputType == _selectInputType;
      string buttonText = "Включить управление ";

      switch (_selectInputType)
      {
        case InputType.Keyboard:
          buttonText += "клавиатурой";
          break;
        case InputType.Brain:
          buttonText += "ИМК";
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      _buttonText.text = buttonText;
      _button.interactable = !isEnabledCurrentType;
    }

    private void SelectInputType()
    {
      _presenter.SetInputType(_selectInputType);
    }
  }
}