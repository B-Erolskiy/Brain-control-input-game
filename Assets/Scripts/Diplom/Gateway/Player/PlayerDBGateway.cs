using System;

namespace Diplom.Gateway.Player
{
  public class PlayerDBGateway : IPlayerDBGateway
  {
    private readonly Entities.Player.Player _player;
    
    public PlayerDBGateway()
    {
      _player = new Entities.Player.Player();
    }

    public Entities.Player.Player GetPlayer() => _player;

    public float GetForwardSpeed() => _player.ForwardSpeed;

    public void SetForwardSpeed(float newForwardSpeed)
    {
      _player.ForwardSpeed = newForwardSpeed;
    }

    public float GetHorizontalSpeed() => _player.HorizontalSpeed;

    public void SetHorizontalSpeed(float newHorizontalSpeed)
    {
      _player.HorizontalSpeed = newHorizontalSpeed;
    }

    public int GetProgress() => _player.Progress;

    public void SetProgress(int newProgressValue)
    {
      _player.Progress = newProgressValue;
    }

    public int GetHealth() => _player.Health;

    public void SetHealth(int newHealthValue)
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