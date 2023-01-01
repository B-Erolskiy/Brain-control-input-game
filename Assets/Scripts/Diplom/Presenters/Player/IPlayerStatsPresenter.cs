using System;
using UniRx;

namespace Diplom.Presenters.Player
{
  public interface IPlayerStatsPresenter
  {
    IReadOnlyReactiveProperty<float> ForwardSpeed { get; }
    IReadOnlyReactiveProperty<float> HorizontalSpeed { get; }
    IReadOnlyReactiveProperty<float> HorizontalMovement { get; }
    IReadOnlyReactiveProperty<float> Progress { get; }
    IReadOnlyReactiveProperty<float> Health { get; }
    IReadOnlyReactiveProperty<DateTime> StartTime { get; }
    IReadOnlyReactiveProperty<DateTime> EndTime { get; }
    IReadOnlyReactiveProperty<bool> IsDead { get; }

    void SetDeadState(bool isDead);
    void SetHorizontalMovement(float newHorizontalMovement);
    void IncreaseSpeed();
    void DecreaseSpeed();
    void IncreaseProgress();
    void SetDamage(float damage);
    void SetStartTime(DateTime startTime);
    TimeSpan GetResultTime();
  }
}