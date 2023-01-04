using Diplom.Usecases.Input.Keyboard;
using UniRx;

namespace Diplom.Presenters.Input.Keyboard
{
  public class KeyboardInputPresenter : IKeyboardInputPresenter
  {
    public IReadOnlyReactiveProperty<float> KeyboardHorizontalMovement => _horizontalMovement;
    private readonly ReactiveProperty<float> _horizontalMovement = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<bool> Enabled => _enabled;
    private readonly ReactiveProperty<bool> _enabled = new ReactiveProperty<bool>();

    private IKeyboardInputUsecase _usecase;

    public KeyboardInputPresenter(IKeyboardInputUsecase usecase)
    {
      _usecase = usecase;
      _usecase.KeyboardHorizontalMovement.Subscribe(UpdateKeyboardHorizontalMovement);
      _usecase.Enabled.Subscribe(UpdateEnableState);
    }

    private void UpdateEnableState(bool newEnableState)
    {
      _enabled.SetValueAndForceNotify(newEnableState);
    }

    private void UpdateKeyboardHorizontalMovement(float newKeyboardHorizontalMovement)
    {
      _horizontalMovement.SetValueAndForceNotify(newKeyboardHorizontalMovement);
    }

    public void SetHorizontalMovement(float newKeyboardHorizontalMovement)
    {
      _usecase.SetHorizontalMovement(newKeyboardHorizontalMovement);
    }
  }
}