using System;
using Diplom.Gateway.Player;
using UniRx;
using UnityEngine;

namespace Diplom.Usecases.Player
{
  public class PlayerUsecase : IPlayerUsecase
  {
    public IReadOnlyReactiveProperty<Entities.Player> Player => _player;
    private readonly ReactiveProperty<Entities.Player> _player = new ReactiveProperty<Entities.Player>();
    
    private const float MinForwardSpeed = 5f, MaxForwardSpeed = 30f, ForwardSpeedStep = 1f;
    private const float MinHorizontalSpeed = 8f, MaxHorizontalSpeed = 17f, HorizontalSpeedStep = 0.6f;
    
    private readonly IPlayerDBGateway _gateway;

    public PlayerUsecase(IPlayerDBGateway gateway)
    {
      _gateway = gateway;
      
      var player = gateway.GetPlayer();
      _player.SetValueAndForceNotify(player);
    }
    
    public void SetHorizontalMovement(float horizontalMovement)
    {
      var newHorizontalMovement = Mathf.Clamp(horizontalMovement, -1, 1);
      _gateway.SetHorizontalMovement(newHorizontalMovement);
      
      var player = _player.Value;
      player.HorizontalMovement = newHorizontalMovement;
      _player.SetValueAndForceNotify(player);
    }
    
    public void IncreaseSpeed()
    {
      var forwardSpeed = _gateway.GetForwardSpeed();
      var newForwardSpeed = Math.Min(forwardSpeed + ForwardSpeedStep, MaxForwardSpeed);
      _gateway.SetForwardSpeed(newForwardSpeed);
      
      var horizontalSpeed = _gateway.GetHorizontalSpeed();
      var newHorizontalSpeed = Math.Min(horizontalSpeed + HorizontalSpeedStep, MaxHorizontalSpeed);
      _gateway.SetHorizontalSpeed(newHorizontalSpeed);

      var player = _player.Value;
      player.ForwardSpeed = newForwardSpeed;
      player.HorizontalSpeed = newHorizontalSpeed;
      
      _player.SetValueAndForceNotify(player);
    }

    public void DecreaseSpeed()
    {
      var forwardSpeed = _gateway.GetForwardSpeed();
      var newForwardSpeed = Math.Max(forwardSpeed - ForwardSpeedStep, MinForwardSpeed);
      _gateway.SetForwardSpeed(newForwardSpeed);
      
      var horizontalSpeed = _gateway.GetHorizontalSpeed();
      var newHorizontalSpeed = Math.Max(horizontalSpeed - HorizontalSpeedStep, MinHorizontalSpeed);
      _gateway.SetHorizontalSpeed(newHorizontalSpeed);

      var player = _player.Value;
      player.ForwardSpeed = newForwardSpeed;
      player.HorizontalSpeed = newHorizontalSpeed;
      
      _player.SetValueAndForceNotify(player);
    }

    public void IncreaseProgress()
    {
      var progress = _gateway.GetProgress();
      var newProgress = progress + 1;
      _gateway.SetProgress(newProgress);

      var player = _player.Value;
      player.Progress = newProgress;
      _player.SetValueAndForceNotify(player);
    }

    public void SetDamage(float damage)
    {
      var health = _gateway.GetHealth();
      var newHealth = Math.Max(health - damage, 0);
      _gateway.SetHealth(newHealth);
      
      var player = _player.Value;
      player.Health = newHealth;
      _player.SetValueAndForceNotify(player);

      var isDead = newHealth == 0;
      if (isDead)
      {
        SetDeadState(true);
      }
    }

    public void SetDeadState(bool isDead)
    {
      var lastDeadState = _gateway.GetIsDead();
      _gateway.SetDeadState(isDead);
      
      if (isDead && !lastDeadState)
      {
        SetEndTime(DateTime.Now);
      }
      
      var player = _player.Value;
      player.IsDead = isDead;
      _player.SetValueAndForceNotify(player);

      
      if (!isDead) return;
      
      var health = _gateway.GetHealth();
      if (health == 0) return;
      
      _gateway.SetHealth(0);
      player = _player.Value;
      player.Health = 0;
      _player.SetValueAndForceNotify(player);
    }

    public void SetStartTime(DateTime startTime)
    {
      _gateway.SetStartTime(startTime);
      
      var player = _player.Value;
      player.StartTime = startTime;
      _player.SetValueAndForceNotify(player);
    }

    public void SetEndTime(DateTime endTime)
    {
      _gateway.SetEndTime(endTime);
      
      var player = _player.Value;
      player.EndTime = endTime;
      _player.SetValueAndForceNotify(player);
    }

    public TimeSpan GetResultTime()
    {
      var startTime = _gateway.GetStartTime();
      var endTime = _gateway.GetEndTime();
      var resultTime = endTime - startTime;
      
      return resultTime;
    }
  }
}