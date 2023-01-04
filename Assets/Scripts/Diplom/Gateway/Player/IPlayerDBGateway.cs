using System;

namespace Diplom.Gateway.Player
{
  public interface IPlayerDBGateway
  {
    Entities.Player.Player GetPlayer();
    float GetForwardSpeed();
    void SetForwardSpeed(float newForwardSpeed);
    float GetHorizontalSpeed();
    void SetHorizontalSpeed(float newHorizontalSpeed);
    int GetProgress();
    void SetProgress(int newProgressValue);
    int GetHealth();
    void SetHealth(int newHealthValue);
    DateTime GetStartTime();
    void SetStartTime(DateTime newStartTime);
    DateTime GetEndTime();
    void SetEndTime(DateTime newEndTime);
    bool GetIsDead();
    void SetDeadState(bool isDead);
  }
}