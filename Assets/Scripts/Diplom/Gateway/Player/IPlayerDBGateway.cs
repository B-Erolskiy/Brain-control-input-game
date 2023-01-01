using System;

namespace Diplom.Gateway.Player
{
  public interface IPlayerDBGateway
  {
    Entities.Player GetPlayer();
    float GetForwardSpeed();
    void SetForwardSpeed(float newForwardSpeed);
    float GetHorizontalSpeed();
    float GetHorizontalMovement();
    void SetHorizontalMovement(float newHorizontalMovement);
    void SetHorizontalSpeed(float newHorizontalSpeed);
    float GetProgress();
    void SetProgress(float newProgressValue);
    float GetHealth();
    void SetHealth(float newHealthValue);
    DateTime GetStartTime();
    void SetStartTime(DateTime newStartTime);
    DateTime GetEndTime();
    void SetEndTime(DateTime newEndTime);
    bool GetIsDead();
    void SetDeadState(bool isDead);
  }
}