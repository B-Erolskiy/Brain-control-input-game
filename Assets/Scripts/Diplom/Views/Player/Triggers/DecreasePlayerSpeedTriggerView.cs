using Diplom.Presenters.Player;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.Triggers
{
  public class DecreasePlayerSpeedTriggerView : MonoBehaviour
  {
    [SerializeField] private string _playerTagName = "Player";
    [SerializeField] private bool _isTrigger;
    
    private IPlayerStatsPresenter _presenter;
    
    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void OnTriggerEnter(Collider other)
    {
      if (_isTrigger && !other.gameObject.CompareTag(_playerTagName)) return;
        
      _presenter.DecreaseSpeed();
    }

    private void OnCollisionEnter(Collision other)
    {
      if (!_isTrigger && !other.gameObject.CompareTag(_playerTagName)) return;
        
      _presenter.DecreaseSpeed();
    }
  }
}