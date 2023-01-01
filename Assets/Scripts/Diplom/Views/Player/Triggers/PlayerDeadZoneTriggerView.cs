using Diplom.Presenters.Player;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.Triggers
{
  public class PlayerDeadZoneTriggerView : MonoBehaviour
  {
    [SerializeField] private string _playerTagName = "Player";
    
    private IPlayerStatsPresenter _presenter;
    
    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void OnTriggerEnter(Collider other)
    {
      if (!other.gameObject.CompareTag(_playerTagName)) return;
        
      _presenter.SetDeadState(true);
    }
  }
}