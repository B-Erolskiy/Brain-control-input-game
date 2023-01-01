using Diplom.Presenters.PlayerUI;
using Diplom.Views.Base.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.GameSceneUI
{
  public class LoseScreenView : BaseScreenView
  {
    [SerializeField] private Button _replayButton;
    
    private IPlayerUIPresenter _presenter;
    
    [Inject]
    private void Construct(IPlayerUIPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void Start()
    {
      _replayButton.onClick.RemoveAllListeners();
      _replayButton.onClick.AddListener(() => _presenter.ReplayGame());
      
      _presenter.IsLoseScreenActive.Subscribe(OnScreenActiveStateChange).AddTo(this);
    }
  }
}