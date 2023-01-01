using Diplom.Presenters.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.Movement
{
  [RequireComponent(typeof(Rigidbody))]
  public class PlayerHorizontalMovementView : MonoBehaviour
  {
    private Rigidbody _body;
    private float _horizontalSpeed, _horizontalMovement;
    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _body = GetComponent<Rigidbody>();

      _presenter.HorizontalSpeed.Subscribe(UpdateHorizontalSpeed).AddTo(this);
      _presenter.HorizontalMovement.Subscribe(UpdateHorizontalMovement).AddTo(this);
      Observable.EveryFixedUpdate().Subscribe(x => MoveHorizontal()).AddTo(this);
    }

    private void UpdateHorizontalSpeed(float newHorizontalSpeed)
    {
      _horizontalSpeed = newHorizontalSpeed;
    }

    private void UpdateHorizontalMovement(float newHorizontalMovement)
    {
      _horizontalMovement = newHorizontalMovement;
    }

    private void MoveHorizontal()
    {
      _body.AddForce(Vector3.right * (_horizontalSpeed * _horizontalMovement), ForceMode.Force);
    }
  }
}