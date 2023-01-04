using System;
using Diplom.Entities.Input;
using Diplom.Gateway.Input;
using Diplom.Usecases.BrainStats;
using Diplom.Usecases.Input.Keyboard;
using UniRx;
using UnityEngine;

namespace Diplom.Usecases.Input
{
  public class InputUsecase : IInputUsecase, IDisposable
  {
    public IReadOnlyReactiveProperty<Entities.Input.Input> Input => _input;
    private readonly ReactiveProperty<Entities.Input.Input> _input = new ReactiveProperty<Entities.Input.Input>();
    
    private readonly IInputDBGateway _gateway;
    private readonly IKeyboardInputUsecase _keyboardInputUsecase;
    private readonly IBrainStatsUsecase _brainStatsUsecase;
    private readonly IDisposable _subscribeKeyboardInput, _subscribeBrainStats;

    public InputUsecase(
      IInputDBGateway gateway,
      IKeyboardInputUsecase keyboardInputUsecase,
      IBrainStatsUsecase brainStatsUsecase)
    {
      _gateway = gateway;
      _keyboardInputUsecase = keyboardInputUsecase;
      _brainStatsUsecase = brainStatsUsecase;

      var inputData = gateway.GetInputData();
      _input.SetValueAndForceNotify(inputData);

      SetInputType(InputType.Keyboard);

      _subscribeKeyboardInput = keyboardInputUsecase.KeyboardHorizontalMovement.Subscribe(UpdateKeyboardHorizontalMovement);
      _subscribeBrainStats = brainStatsUsecase.BrainStats.Subscribe(UpdateBrainStatsMovement);
    }

    private void UpdateBrainStatsMovement(Entities.BrainStats.BrainStats newBrainStats)
    {
      if (!_input.HasValue || _input.Value.InputType != InputType.Brain) return;

      var newBrainHorizontalMovement = 
        Math.Abs(newBrainStats.ConcentrationPercent - newBrainStats.MeditationPercent) < 1 ? 0 
          : newBrainStats.ConcentrationPercent > newBrainStats.MeditationPercent ? 1 : -1;
      SetHorizontalMovement(newBrainHorizontalMovement);
    }

    private void UpdateKeyboardHorizontalMovement(float newKeyboardHorizontalMovement)
    {
      if (!_input.HasValue || _input.Value.InputType != InputType.Keyboard) return;
      
      SetHorizontalMovement(newKeyboardHorizontalMovement);
    }
    
    private void SetHorizontalMovement(float horizontalMovement)
    {
      var newHorizontalMovement = Mathf.Clamp(horizontalMovement, -1, 1);
      _gateway.SetHorizontalMovement(newHorizontalMovement);

      var input = _input.Value;
      input.HorizontalMovement = _gateway.GetHorizontalMovement();
      
      _input.SetValueAndForceNotify(input);
    }
    
    public void SetInputType(InputType newInputType)
    {
      _gateway.SetInputType(newInputType);

      var input = _input.Value;
      input.InputType = _gateway.GetInputType();
      
      _input.SetValueAndForceNotify(input);
      
      _brainStatsUsecase.SetAnalyseBrainActivityState(newInputType == InputType.Brain);
      _keyboardInputUsecase.SetEnabledState(newInputType == InputType.Keyboard);
    }

    public void Dispose()
    {
      _input?.Dispose();
      _subscribeKeyboardInput?.Dispose();
      _subscribeBrainStats?.Dispose();
    }
  }
}