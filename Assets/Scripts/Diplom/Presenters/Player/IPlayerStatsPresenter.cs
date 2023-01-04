using System;
using UniRx;
using UnityEngine;

namespace Diplom.Presenters.Player
{
  public interface IPlayerStatsPresenter
  {
    IReadOnlyReactiveProperty<float> ForwardSpeed { get; }
    IReadOnlyReactiveProperty<Vector3> HorizontalForce { get; }
    IReadOnlyReactiveProperty<int> Progress { get; }
    IReadOnlyReactiveProperty<int> Health { get; }
    IReadOnlyReactiveProperty<DateTime> StartTime { get; }
    IReadOnlyReactiveProperty<DateTime> EndTime { get; }
    IReadOnlyReactiveProperty<bool> IsDead { get; }

    void SetDeadState(bool isDead);
    void IncreaseSpeed();
    void DecreaseSpeed();
    void IncreaseProgress();
    void SetDamage(int damage);
    void SetStartTime(DateTime startTime);
    TimeSpan GetResultTime();
  }
}