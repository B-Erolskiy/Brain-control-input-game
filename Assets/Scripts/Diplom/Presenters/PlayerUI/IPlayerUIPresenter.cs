using UniRx;

namespace Diplom.Presenters.PlayerUI
{
  public interface IPlayerUIPresenter
  {
    IReadOnlyReactiveProperty<bool> IsInGameScreenActive { get; }
    IReadOnlyReactiveProperty<bool> IsSettingsScreenActive { get; }
    IReadOnlyReactiveProperty<bool> IsLoseScreenActive { get; }
    IReadOnlyReactiveProperty<bool> IsPauseScreenActive { get; }

    void OpenSettingsScreen();
    void CloseSettingsScreen();
    void OpenPauseScreen();
    void ClosePauseScreen();
    void OpenLoseScreen();
    void CloseLoseScreen();
    void QuitGame();
    void ReplayGame();
  }
}