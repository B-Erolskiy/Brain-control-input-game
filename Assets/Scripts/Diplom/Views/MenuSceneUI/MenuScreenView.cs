using Diplom.Presenters.MenuSceneUI;
using Diplom.Views.Base.UI;
using UniRx;
using Zenject;

namespace Diplom.Views.MenuSceneUI
{
  public class MenuScreenView : BaseScreenView
  {
    private IMenuSceneUIPresenter _presenter;

    [Inject]
    private void Construct(IMenuSceneUIPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _presenter.IsMenuScreenActive.Subscribe(OnScreenActiveStateChange).AddTo(this);
    }
  }
}