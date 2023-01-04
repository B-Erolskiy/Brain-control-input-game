using System;
using Diplom.Entities.Input;
using Diplom.Presenters.Input.Brain;
using Diplom.Presenters.Input.Keyboard;
using Diplom.Usecases.Input;
using UniRx;

namespace Diplom.Presenters.Input
{
  public class InputPresenter : IInputPresenter, IDisposable
  {
    public IReadOnlyReactiveProperty<InputType> InputType => _inputType;
    private readonly ReactiveProperty<InputType> _inputType = new ReactiveProperty<InputType>();
    public IReadOnlyReactiveProperty<float> HorizontalMovement => _horizontalMovement;
    private readonly ReactiveProperty<float> _horizontalMovement = new ReactiveProperty<float>();
    
    private readonly IInputUsecase _usecase;
    private readonly IDisposable _inputSubscribe, _brainInputSubscribe, _keyboardInputSubscribe;
    private IBrainStatsPresenter _brainStatsPresenter;
    private IKeyboardInputPresenter _keyboardInputPresenter;

    public InputPresenter(IInputUsecase usecase)
    {
      _usecase = usecase;

      _inputSubscribe = _usecase.Input.Subscribe(UpdateInputData);

      UpdateInputData(_usecase.Input.Value);
    }

    private void UpdateInputData(Entities.Input.Input newInput)
    {
      if (Math.Abs(_horizontalMovement.Value - newInput.HorizontalMovement) > 0.01f)
      {
        _horizontalMovement.SetValueAndForceNotify(newInput.HorizontalMovement);
      }
      if (_inputType.HasValue && _inputType.Value != newInput.InputType)
      {
        _inputType.SetValueAndForceNotify(newInput.InputType);
      }
    }

    public void SetInputType(InputType newInputType)
    {
      _usecase.SetInputType(newInputType);
    }

    public void Dispose()
    {
      _inputType?.Dispose();
      _horizontalMovement?.Dispose();
      _inputSubscribe?.Dispose();
    }
  }
}