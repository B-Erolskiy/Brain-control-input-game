using UniRx;

namespace Diplom.Usecases.BrainStats
{
  public interface IBrainStatsUsecase
  {
    IReadOnlyReactiveProperty<Entities.BrainStats.BrainStats> BrainStats { get; }
    IReadOnlyReactiveProperty<bool> AnalyseBrainActivityState { get; }
    void SetAnalyseBrainActivityState(bool isActive);
  }
}