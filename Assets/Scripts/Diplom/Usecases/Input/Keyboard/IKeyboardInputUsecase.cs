using UniRx;

namespace Diplom.Usecases.Input.Keyboard
{
  public interface IKeyboardInputUsecase
  {
    IReadOnlyReactiveProperty<float> KeyboardHorizontalMovement { get; }
    IReadOnlyReactiveProperty<bool> Enabled { get; }
    void SetHorizontalMovement(float newKeyboardHorizontalMovement);
    void SetEnabledState(bool isEnable);
  }
}