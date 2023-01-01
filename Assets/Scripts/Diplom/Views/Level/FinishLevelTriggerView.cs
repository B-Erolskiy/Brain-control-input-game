using Diplom.Presenters.Level;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Level
{
  public class FinishLevelTriggerView : MonoBehaviour
  {
    [SerializeField] private string _playerTagName = "Player";
    
    private ILevelBuilderPresenter _presenter;
    
    [Inject]
    private void Construct(ILevelBuilderPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void OnTriggerEnter(Collider other)
    {
      if (!other.gameObject.CompareTag(_playerTagName)) return;
        
      _presenter.FinishLevel();
    }
  }
}