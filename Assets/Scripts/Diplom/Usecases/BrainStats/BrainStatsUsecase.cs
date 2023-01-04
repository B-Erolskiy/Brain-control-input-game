using Diplom.Gateway.BrainStats;
using UniRx;

namespace Diplom.Usecases.BrainStats
{
  public class BrainStatsUsecase : IBrainStatsUsecase
  {
    public IReadOnlyReactiveProperty<Entities.BrainStats.BrainStats> BrainStats => _brainStats;
    private readonly ReactiveProperty<Entities.BrainStats.BrainStats> _brainStats = new ReactiveProperty<Entities.BrainStats.BrainStats>();
    public IReadOnlyReactiveProperty<bool> AnalyseBrainActivityState => _analyseBrainActivityState;
    private readonly ReactiveProperty<bool> _analyseBrainActivityState = new ReactiveProperty<bool>();
    private readonly IBrainStatsGateway _gateway;

    public BrainStatsUsecase(IBrainStatsGateway gateway)
    {
      _gateway = gateway;
      
      _brainStats.SetValueAndForceNotify(new Entities.BrainStats.BrainStats());
      _analyseBrainActivityState.SetValueAndForceNotify(true);

      UpdateBrainStats();
    }

    private void UpdateBrainStats()
    {
      if (!_analyseBrainActivityState.Value) return;
      
      _gateway.GetBrainStats().Subscribe(newBrainStats =>
      {
        _brainStats.SetValueAndForceNotify(newBrainStats);
        UpdateBrainStats();
      });
    }

    public void SetAnalyseBrainActivityState(bool isActive)
    {
      if (_analyseBrainActivityState.HasValue && _analyseBrainActivityState.Value == isActive) return;
      
      _analyseBrainActivityState.SetValueAndForceNotify(isActive);
      if (!isActive) return;
      
      UpdateBrainStats();
    }
  }
}