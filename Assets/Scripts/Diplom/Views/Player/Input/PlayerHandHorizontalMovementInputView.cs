using Diplom.Presenters.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.Input
{
  public class PlayerHandHorizontalMovementInputView : MonoBehaviour
  {
    private IPlayerStatsPresenter _presenter;
    private PlayerControls _playerControls;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _playerControls = new PlayerControls();
      _presenter = presenter;
    }

    private void Start()
    {
      Observable.EveryFixedUpdate().Subscribe(x => CheckHorizontalMovement()).AddTo(this);
    }

    private void CheckHorizontalMovement()
    {
      var horizontalMovement = _playerControls.Player.HorizontalMove.ReadValue<float>();
      _presenter.SetHorizontalMovement(horizontalMovement);
    }

    private void OnEnable()
    {
      _playerControls.Enable();
    }

    private void OnDisable()
    {
      _playerControls.Disable();
    }

    private void OnDestroy()
    {
      _playerControls.Dispose();
    }
  }
}