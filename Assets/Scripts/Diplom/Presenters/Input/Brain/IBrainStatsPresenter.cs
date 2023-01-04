using UniRx;

namespace Diplom.Presenters.Input.Brain
{
  public interface IBrainStatsPresenter
  {
    IReadOnlyReactiveProperty<int> ConcentrationPercent { get; }
    IReadOnlyReactiveProperty<int> MeditationPercent { get; }
    IReadOnlyReactiveProperty<double> ServerPing { get; }
    IReadOnlyReactiveProperty<bool> AnalyseBrainActivityState { get; }

    void SetAnalyseBrainActivityState(bool isActive);
  }
}