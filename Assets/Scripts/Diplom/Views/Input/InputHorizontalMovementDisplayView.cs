using System.Collections.Generic;
using Diplom.Presenters.Input;
using Diplom.Views.Player.Movement;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Input
{
  public class InputHorizontalMovementDisplayView : MonoBehaviour
  {
    [SerializeField] private List<ColorByNumberDisplayView> _colorMovementViews;
    
    private IInputPresenter _presenter;

    [Inject]
    private void Construct(IInputPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _presenter.HorizontalMovement.Subscribe(UpdateHorizontalMovementDirection).AddTo(this);
    }

    private void UpdateHorizontalMovementDirection(float horizontalMovement)
    {
      _colorMovementViews.ForEach(view => view.SetNumber(horizontalMovement));
    }
  }
}