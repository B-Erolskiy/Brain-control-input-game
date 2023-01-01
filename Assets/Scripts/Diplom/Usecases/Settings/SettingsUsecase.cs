using Diplom.Gateway.Settings;
using UniRx;

namespace Diplom.Usecases.Settings
{
  public class SettingsUsecase : ISettingsUsecase
  {
    public IReadOnlyReactiveProperty<float> TotalVolume => _totalVolume;
    private readonly ReactiveProperty<float> _totalVolume = new ReactiveProperty<float>();
    public IReadOnlyReactiveProperty<bool> IsVolumeEnabled => _isVolumeEnabled;
    private readonly ReactiveProperty<bool> _isVolumeEnabled = new ReactiveProperty<bool>();
    
    private readonly ISettingsDBGateway _gateway;

    public SettingsUsecase(ISettingsDBGateway gateway)
    {
      _gateway = gateway;

      _totalVolume.Value = gateway.GetTotalVolume();
      _isVolumeEnabled.Value = gateway.GetVolumeEnableState();
    }
    
    public void SetTotalVolume(float newTotalVolumeState)
    {
      _gateway.SetTotalVolume(newTotalVolumeState);

      var updatedTotalVolume = _gateway.GetTotalVolume();
      _totalVolume.SetValueAndForceNotify(updatedTotalVolume);
    }

    public void SetVolumeEnableState(bool newVolumeEnabledState)
    {
      _gateway.SetVolumeEnabledState(newVolumeEnabledState);

      var updatedVolumeEnableState = _gateway.GetVolumeEnableState();
      _isVolumeEnabled.SetValueAndForceNotify(updatedVolumeEnableState);
    }
  }
}