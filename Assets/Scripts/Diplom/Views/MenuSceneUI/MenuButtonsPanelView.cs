using Diplom.Presenters.MenuSceneUI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.MenuSceneUI
{
  public class MenuButtonsPanelView : MonoBehaviour
  {
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _quitButton;
    
    private IMenuUIPresenter _presenter;

    [Inject]
    private void Construct(IMenuUIPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _startGameButton.OnClickAsObservable().Subscribe(_ => _presenter.StartGame());
      _settingsButton.OnClickAsObservable().Subscribe(_ => _presenter.OpenSettings());
      _quitButton.OnClickAsObservable().Subscribe(_ => _presenter.QuitGame());
    }
  }
}