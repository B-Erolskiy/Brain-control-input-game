using Diplom.Presenters.PlayerUI;
using Diplom.Views.Base.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.GameSceneUI
{
  public class InGameScreenView : BaseScreenView
  {
    [SerializeField] private Button _pauseButton;

    private IPlayerUIPresenter _presenter;
    
    [Inject]
    private void Construct(IPlayerUIPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void Start()
    {
      _pauseButton.OnClickAsObservable().Subscribe(_ => _presenter.OpenPauseScreen()).AddTo(_pauseButton);

      _presenter.IsInGameScreenActive.Subscribe(OnScreenActiveStateChange).AddTo(this);
    }
  }
}