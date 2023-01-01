using Diplom.Presenters.PlayerUI;
using Diplom.Views.Base.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.GameSceneUI
{
  public class PauseScreenView : BaseScreenView
  {
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _quitButton;
    
    private IPlayerUIPresenter _presenter; //todo replace to pause presenter
    
    [Inject]
    private void Construct(IPlayerUIPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void Start()
    {
      _continueButton.onClick.RemoveAllListeners();
      _continueButton.onClick.AddListener(() => _presenter.ClosePauseScreen());
      
      _replayButton.onClick.RemoveAllListeners();
      _replayButton.onClick.AddListener(() => _presenter.ReplayGame());
      
      _settingsButton.onClick.RemoveAllListeners();
      _settingsButton.onClick.AddListener(() => _presenter.OpenSettingsScreen());
      
      _quitButton.onClick.RemoveAllListeners();
      _quitButton.onClick.AddListener(() => _presenter.QuitGame());
      
      _presenter.IsPauseScreenActive.Subscribe(OnScreenActiveStateChange).AddTo(this);
    }
  }
}