using Diplom.Presenters.MenuSceneUI;
using Diplom.Views.Base.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.MenuSceneUI
{
  public class MenuSettingsScreenView : BaseScreenView
  {
    [SerializeField] private Button _hideButton;

    private IMenuSceneUIPresenter _presenter;
    
    [Inject]
    private void Construct(IMenuSceneUIPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void Start()
    {
      _hideButton.OnClickAsObservable().Subscribe(_ => _presenter.CloseSettingsScreen()).AddTo(_hideButton);
      
      _presenter.IsSettingsScreenActive.Subscribe(OnScreenActiveStateChange).AddTo(this);
    }
    
    
  }
}