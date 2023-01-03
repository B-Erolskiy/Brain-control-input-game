using System.Collections.Generic;
using Diplom.Presenters.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.Movement
{
  public class PlayerMovementDisplayView : MonoBehaviour
  {
    [SerializeField] private List<ColorByNumberDisplayView> _colorMovementViews;
    
    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
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