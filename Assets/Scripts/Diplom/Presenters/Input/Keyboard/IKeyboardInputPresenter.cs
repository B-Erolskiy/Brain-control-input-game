using UniRx;

namespace Diplom.Presenters.Input.Keyboard
{
  public interface IKeyboardInputPresenter
  {
    IReadOnlyReactiveProperty<float> KeyboardHorizontalMovement { get; }
    IReadOnlyReactiveProperty<bool> Enabled { get; }
    void SetHorizontalMovement(float newKeyboardHorizontalMovement);
  }
}