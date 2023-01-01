using Diplom.Presenters.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.Movement
{
  [RequireComponent(typeof(Rigidbody))]
  public class PlayerForwardMovementView : MonoBehaviour
  {
    private Rigidbody _body;
    private float _forwardSpeed;
    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _body = GetComponent<Rigidbody>();

      _presenter.ForwardSpeed.Subscribe(UpdateForwardSpeed).AddTo(this);
      Observable.EveryFixedUpdate().Subscribe(x => MoveForward()).AddTo(this);
    }

    private void UpdateForwardSpeed(float newForwardSpeed)
    {
      _forwardSpeed = newForwardSpeed;
    }

    private void MoveForward()
    {
      _body.AddForce(Vector3.forward * _forwardSpeed, ForceMode.Force);
    }
  }
}