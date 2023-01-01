using System;
using Diplom.Usecases.Settings;
using UniRx;

namespace Diplom.Presenters.Settings
{
  public class SettingsPresenter : ISettingsPresenter, IDisposable
  {
    public IReadOnlyReactiveProperty<float> TotalVolume => _totalVolume;
    private readonly ReactiveProperty<float> _totalVolume = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<bool> IsVolumeEnabled => _isVolumeEnabled;
    private readonly ReactiveProperty<bool> _isVolumeEnabled = new ReactiveProperty<bool>();

    private ISettingsUsecase _usecase;
    private IDisposable _totalVolumeSubscribe, _isVolumeEnableSubscribe;
    
    public void Initialize(ISettingsUsecase usecase)
    {
      _usecase = usecase;
      _totalVolumeSubscribe = _usecase.TotalVolume.Subscribe(UpdateTotalVolume);
      _isVolumeEnableSubscribe = _usecase.IsVolumeEnabled.Subscribe(UpdateVolumeEnableState);

      UpdateTotalVolume(_usecase.TotalVolume.Value);
      UpdateVolumeEnableState(_usecase.IsVolumeEnabled.Value);
    }

    private void UpdateTotalVolume(float newTotalVolumeValue)
    {
      if (_totalVolume.HasValue && Math.Abs(_totalVolume.Value - newTotalVolumeValue) < 0.01f) return;
      
      _totalVolume.SetValueAndForceNotify(newTotalVolumeValue);
    }

    private void UpdateVolumeEnableState(bool newVolumeEnableState)
    {
      if (_isVolumeEnabled.HasValue && _isVolumeEnabled.Value == newVolumeEnableState) return;
      
      _isVolumeEnabled.SetValueAndForceNotify(newVolumeEnableState);
    }

    #region Public methods
    
    public void SetTotalVolume(float newTotalVolumeValue)
    {
      _usecase.SetTotalVolume(newTotalVolumeValue);
    }

    public void SetVolumeEnableState(bool newVolumeEnableValue)
    {
      _usecase.SetVolumeEnableState(newVolumeEnableValue);
    }

    public void Dispose()
    {
      _totalVolume?.Dispose();
      _isVolumeEnabled?.Dispose();
      _totalVolumeSubscribe?.Dispose();
      _isVolumeEnableSubscribe?.Dispose();
    }

    #endregion
  }
}