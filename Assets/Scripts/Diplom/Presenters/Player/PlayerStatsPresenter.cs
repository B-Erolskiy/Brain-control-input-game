using System;
using Diplom.Usecases.Player;
using UniRx;

namespace Diplom.Presenters.Player
{
  public class PlayerStatsPresenter : IPlayerStatsPresenter, IDisposable
  {
    public IReadOnlyReactiveProperty<float> ForwardSpeed => _forwardSpeed;
    private readonly ReactiveProperty<float> _forwardSpeed = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> HorizontalSpeed => _horizontalSpeed;
    private readonly ReactiveProperty<float> _horizontalSpeed = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> HorizontalMovement => _horizontalMovement;
    private readonly ReactiveProperty<float> _horizontalMovement = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> Progress => _progress;
    private readonly ReactiveProperty<float> _progress = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<float> Health => _health;
    private readonly ReactiveProperty<float> _health = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<DateTime> StartTime => _startTime;
    private readonly ReactiveProperty<DateTime> _startTime = new ReactiveProperty<DateTime>();
    public IReadOnlyReactiveProperty<DateTime> EndTime => _endTime;
    private readonly ReactiveProperty<DateTime> _endTime = new ReactiveProperty<DateTime>();
    public IReadOnlyReactiveProperty<bool> IsDead => _isDead;
    private readonly ReactiveProperty<bool> _isDead = new ReactiveProperty<bool>();
    
    private IPlayerUsecase _usecase;
    private IDisposable _playerSubscribe;
    
    public void Initialize(IPlayerUsecase usecase)
    {
      _usecase = usecase;

      _playerSubscribe = _usecase.Player.Subscribe(UpdatePlayerData);

      UpdatePlayerData(_usecase.Player.Value);
    }

    private void UpdatePlayerData(Entities.Player player)
    {
      if (player == null) return;
      
      if (Math.Abs(_forwardSpeed.Value - player.ForwardSpeed) > 0.01f)
      {
        _forwardSpeed.SetValueAndForceNotify(player.ForwardSpeed);
      }
      if (Math.Abs(_horizontalSpeed.Value - player.HorizontalSpeed) > 0.01f)
      {
        _horizontalSpeed.SetValueAndForceNotify(player.HorizontalSpeed);
      }
      if (Math.Abs(_horizontalMovement.Value - player.HorizontalMovement) > 0.01f)
      {
        _horizontalMovement.SetValueAndForceNotify(player.HorizontalMovement);
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

    public void SetHorizontalMovement(float newHorizontalMovement)
    {
      _usecase.SetHorizontalMovement(newHorizontalMovement);
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

    public void SetDamage(float damage)
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
      _horizontalSpeed?.Dispose();
      _horizontalMovement?.Dispose();
      _progress?.Dispose();
      _health?.Dispose();
      _startTime?.Dispose();
      _endTime?.Dispose();
      _isDead?.Dispose();
      _playerSubscribe?.Dispose();
    }

    #endregion
  }
}