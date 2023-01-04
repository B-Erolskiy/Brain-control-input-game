using System;
using Diplom.Entities.BrainStats;
using Diplom.Usecases.BrainStats;
using UniRx;

namespace Diplom.Presenters.Input.Brain
{
  public class BrainStatsPresenter : IBrainStatsPresenter, IDisposable
  {
    public IReadOnlyReactiveProperty<int> ConcentrationPercent => _concentrationPercent;
    private readonly ReactiveProperty<int> _concentrationPercent = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> MeditationPercent => _meditationPercent;
    private readonly ReactiveProperty<int> _meditationPercent = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<double> ServerPing => _serverPing;
    private readonly ReactiveProperty<double> _serverPing = new ReactiveProperty<double>();
    public IReadOnlyReactiveProperty<bool> AnalyseBrainActivityState => _analyseBrainActivityState;
    private readonly ReactiveProperty<bool> _analyseBrainActivityState = new ReactiveProperty<bool>();

    private readonly IBrainStatsUsecase _usecase;
    private readonly IDisposable _brainStatsSubscribe, _analyseBrainActivityStateSubscribe;
    
    public BrainStatsPresenter(IBrainStatsUsecase usecase)
    {
      _usecase = usecase;
      _brainStatsSubscribe = _usecase.BrainStats.Subscribe(UpdateBrainStats);
      _analyseBrainActivityStateSubscribe = _usecase.AnalyseBrainActivityState.Subscribe(UpdateAnalyseBrainActivityState);
    }

    private void UpdateAnalyseBrainActivityState(bool analyseBrainActivityState)
    {
      if (_analyseBrainActivityState.Value == analyseBrainActivityState) return;
      
      _analyseBrainActivityState.SetValueAndForceNotify(analyseBrainActivityState);
    }

    private void UpdateBrainStats(BrainStats newBrainStats)
    {
      if (_concentrationPercent.Value != newBrainStats.ConcentrationPercent)
      {
        _concentrationPercent.SetValueAndForceNotify(newBrainStats.ConcentrationPercent);
      }
      if (_meditationPercent.Value != newBrainStats.MeditationPercent)
      {
        _meditationPercent.SetValueAndForceNotify(newBrainStats.MeditationPercent);
      }
      if (Math.Abs(_serverPing.Value - newBrainStats.ServerPing) > 0.01)
      {
        _serverPing.SetValueAndForceNotify(newBrainStats.ServerPing);
      }
    }
    
    public void SetAnalyseBrainActivityState(bool isActive)
    {
      _usecase.SetAnalyseBrainActivityState(isActive);
    }

    public void Dispose()
    {
      _concentrationPercent?.Dispose();
      _meditationPercent?.Dispose();
      _serverPing?.Dispose();
      _analyseBrainActivityState?.Dispose();
      _brainStatsSubscribe?.Dispose();
    }
  }
}