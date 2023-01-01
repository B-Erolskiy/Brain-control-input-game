using System;

namespace Diplom.Gateway.Player
{
  public class PlayerDBGateway : IPlayerDBGateway
  {
    private readonly Entities.Player _player;
    
    public PlayerDBGateway()
    {
      _player = new Entities.Player();
    }

    public Entities.Player GetPlayer() => _player;

    public float GetForwardSpeed() => _player.ForwardSpeed;

    public void SetForwardSpeed(float newForwardSpeed)
    {
      _player.ForwardSpeed = newForwardSpeed;
    }
    
    public float GetHorizontalMovement() => _player.HorizontalMovement;

    public void SetHorizontalMovement(float newHorizontalMovement)
    {
      _player.HorizontalMovement = newHorizontalMovement;
    }

    public float GetHorizontalSpeed() => _player.HorizontalSpeed;

    public void SetHorizontalSpeed(float newHorizontalSpeed)
    {
      _player.HorizontalSpeed = newHorizontalSpeed;
    }

    public float GetProgress() => _player.Progress;

    public void SetProgress(float newProgressValue)
    {
      _player.Progress = newProgressValue;
    }

    public float GetHealth() => _player.Health;

    public void SetHealth(float newHealthValue)
    {
      _player.Health = newHealthValue;
    }

    public DateTime GetStartTime() => _player.StartTime;

    public void SetStartTime(DateTime newStartTime)
    {
      _player.StartTime = newStartTime;
    }

    public DateTime GetEndTime() => _player.EndTime;

    public void SetEndTime(DateTime newEndTime)
    {
      _player.EndTime = newEndTime;
    }

    public bool GetIsDead() => _player.IsDead;

    public void SetDeadState(bool isDead)
    {
      _player.IsDead = isDead;
    }
  }
}