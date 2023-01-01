namespace Diplom.Gateway.Settings
{
  public interface ISettingsDBGateway
  {
    float GetTotalVolume();
    void SetTotalVolume(float newTotalVolumeValue);
    bool GetVolumeEnableState();
    void SetVolumeEnabledState(bool newVolumeEnabledValue);
  }
}