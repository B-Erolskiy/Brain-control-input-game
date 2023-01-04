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
    private Vector3 _horizontalForce;
    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _body = GetComponent<Rigidbody>();

      _presenter.HorizontalForce.Subscribe(UpdateHorizontalForce).AddTo(this);
      Observable.EveryFixedUpdate().Subscribe(x => MoveHorizontal()).AddTo(this);
    }

    private void UpdateHorizontalForce(Vector3 newHorizontalForce)
    {
      _horizontalForce = newHorizontalForce;
    }

    private void MoveHorizontal()
    {
      _body.AddForce(_horizontalForce, ForceMode.Force);
    }
  }
}