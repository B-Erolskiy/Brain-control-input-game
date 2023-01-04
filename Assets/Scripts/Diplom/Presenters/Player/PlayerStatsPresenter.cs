using System;
using Diplom.Presenters.Input;
using Diplom.Usecases.Player;
using UniRx;
using UnityEngine;

namespace Diplom.Presenters.Player
{
  public class PlayerStatsPresenter : IPlayerStatsPresenter, IDisposable
  {
    public IReadOnlyReactiveProperty<float> ForwardSpeed => _forwardSpeed;
    private readonly ReactiveProperty<float> _forwardSpeed = new ReactiveProperty<float>();
    private float _horizontalSpeed, _horizontalMovement;
    public IReadOnlyReactiveProperty<Vector3> HorizontalForce => _horizontalForce;
    private readonly ReactiveProperty<Vector3> _horizontalForce = new ReactiveProperty<Vector3>();
    public IReadOnlyReactiveProperty<int> Progress => _progress;
    private readonly ReactiveProperty<int> _progress = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<int> Health => _health;
    private readonly ReactiveProperty<int> _health = new ReactiveProperty<int>();
    public IReadOnlyReactiveProperty<DateTime> StartTime => _startTime;
    private readonly ReactiveProperty<DateTime> _startTime = new ReactiveProperty<DateTime>();
    public IReadOnlyReactiveProperty<DateTime> EndTime => _endTime;
    private readonly ReactiveProperty<DateTime> _endTime = new ReactiveProperty<DateTime>();
    public IReadOnlyReactiveProperty<bool> IsDead => _isDead;
    private readonly ReactiveProperty<bool> _isDead = new ReactiveProperty<bool>();
    
    private readonly IPlayerUsecase _usecase;
    private readonly IDisposable _playerSubscribe, _inputHorizontalMovementSubscribe;
    
    public PlayerStatsPresenter(IPlayerUsecase usecase, IInputPresenter inputPresenter)
    {
      _usecase = usecase;

      _playerSubscribe = _usecase.Player.Subscribe(UpdatePlayerData);
      _inputHorizontalMovementSubscribe = inputPresenter.HorizontalMovement.Subscribe(UpdateHorizontalMovement);

      UpdatePlayerData(_usecase.Player.Value);
    }

    private void UpdateHorizontalMovement(float horizontalMovement)
    {
      _horizontalMovement = horizontalMovement;
      UpdateHorizontalForce();
    }

    private void UpdateHorizontalForce()
    {
      var newHorizontalForce = Vector3.right * (_horizontalSpeed * _horizontalMovement);
      _horizontalForce.SetValueAndForceNotify(newHorizontalForce);
    }

    private void UpdatePlayerData(Entities.Player.Player player)
    {
      if (player == null) return;
      
      if (Math.Abs(_forwardSpeed.Value - player.ForwardSpeed) > 0.01f)
      {
        _forwardSpeed.SetValueAndForceNotify(player.ForwardSpeed);
      }
      if (Math.Abs(_horizontalSpeed - player.HorizontalSpeed) > 0.01f)
      {
        _horizontalSpeed = player.HorizontalSpeed;
        UpdateHorizontalForce();
      }
      if (Math.Abs(_progress.Value - player.Progress) > 0.01f)
      {
        _progress.SetValueAndForceNotify(player.Progress);
      }
      if (Math.Abs(_health.Value - player.Health) > 0.01)
      {
        _health.SetValueAndForceNotify(player.Health);
      }
      if (_startTime.Value != player.StartTime && player.StartTime != default)
      {
        _startTime.SetValueAndForceNotify(player.StartTime);
      }
      if (_endTime.Value != player.EndTime && player.EndTime != default)
      {
        _endTime.SetValueAndForceNotify(player.EndTime);
      }
      if (_isDead.Value != player.IsDead)
      {
        _isDead.SetValueAndForceNotify(player.IsDead);
      }
    }

    #region Public methods

    public void SetDeadState(bool isDead)
    {
      _usecase.SetDeadState(isDead);
    }

    public void IncreaseSpeed()
    {
      _usecase.IncreaseSpeed();
    }

    public void DecreaseSpeed()
    {
      _usecase.DecreaseSpeed();
    }

    public void IncreaseProgress()
    {
      _usecase.IncreaseProgress();
    }

    public void SetDamage(int damage)
    {
      _usecase.SetDamage(damage);
    }

    public void SetStartTime(DateTime startTime)
    {
      _usecase.SetStartTime(startTime);
    }

    public TimeSpan GetResultTime()
    {
      return _usecase.GetResultTime();
    }

    public void Dispose()
    {
      _forwardSpeed?.Dispose();
      _horizontalForce?.Dispose();
      _progress?.Dispose();
      _health?.Dispose();
      _startTime?.Dispose();
      _endTime?.Dispose();
      _isDead?.Dispose();
      _playerSubscribe?.Dispose();
      _inputHorizontalMovementSubscribe?.Dispose();
    }

    #endregion
  }
}