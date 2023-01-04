using System;
using UniRx;

namespace Diplom.Usecases.Input.Keyboard
{
  public class KeyboardInputUsecase : IKeyboardInputUsecase
  {
    public IReadOnlyReactiveProperty<float> KeyboardHorizontalMovement => _keyboardHorizontalMovement;
    private readonly ReactiveProperty<float> _keyboardHorizontalMovement = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<bool> Enabled => _enabled;
    private readonly ReactiveProperty<bool> _enabled = new ReactiveProperty<bool>();
    
    public void SetHorizontalMovement(float newKeyboardHorizontalMovement)
    {
      if (Math.Abs(_keyboardHorizontalMovement.Value - newKeyboardHorizontalMovement) < 0.01f) return;
      
      _keyboardHorizontalMovement.SetValueAndForceNotify(newKeyboardHorizontalMovement);
    }

    public void SetEnabledState(bool isEnable)
    {
      _enabled.SetValueAndForceNotify(isEnable);
    }
  }
}