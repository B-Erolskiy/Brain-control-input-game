using UniRx;

namespace Diplom.Presenters.MenuSceneUI
{
  public interface IMenuSceneUIPresenter
  {
    IReadOnlyReactiveProperty<bool> IsMenuScreenActive { get; }
    IReadOnlyReactiveProperty<bool> IsSettingsScreenActive { get; }
    
    void OpenMenuScreen();
    void CloseMenuScreen();
    void OpenSettingsScreen();
    void CloseSettingsScreen();
  }
}