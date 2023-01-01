using System;
using UniRx;

namespace Diplom.Usecases.Player
{
  public interface IPlayerUsecase
  {
    IReadOnlyReactiveProperty<Entities.Player> Player { get; }

    void SetHorizontalMovement(float horizontalMovement);
    void IncreaseSpeed();
    void DecreaseSpeed();
    void IncreaseProgress();
    void SetDamage(float damage);
    void SetStartTime(DateTime startTime);
    void SetEndTime(DateTime endTime);
    TimeSpan GetResultTime();
    void SetDeadState(bool isDead);
  }
}