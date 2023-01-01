using UniRx;

namespace Diplom.Presenters.MenuSceneUI
{
  public class MenuSceneUIPresenter : IMenuSceneUIPresenter
  {
    public IReadOnlyReactiveProperty<bool> IsMenuScreenActive => _isMenuScreenActive;
    private readonly ReactiveProperty<bool> _isMenuScreenActive = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsSettingsScreenActive => _isSettingsScreenActive;
    private readonly ReactiveProperty<bool> _isSettingsScreenActive = new ReactiveProperty<bool>();

    public void Initialize()
    {
      CloseSettingsScreen();
      OpenMenuScreen();
    }
    
    public void OpenMenuScreen()
    {
      _isMenuScreenActive.SetValueAndForceNotify(true);
    }

    public void CloseMenuScreen()
    {
      _isMenuScreenActive.SetValueAndForceNotify(false);
    }

    public void OpenSettingsScreen()
    {
      _isSettingsScreenActive.SetValueAndForceNotify(true);
    }

    public void CloseSettingsScreen()
    {
      _isSettingsScreenActive.SetValueAndForceNotify(false);
    }
  }
}