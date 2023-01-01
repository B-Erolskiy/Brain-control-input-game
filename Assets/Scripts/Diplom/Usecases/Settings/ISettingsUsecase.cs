using UniRx;

namespace Diplom.Usecases.Settings
{
  public interface ISettingsUsecase
  {
    IReadOnlyReactiveProperty<float> TotalVolume { get; }
    IReadOnlyReactiveProperty<bool> IsVolumeEnabled { get; }

    void SetTotalVolume(float newTotalVolumeState);
    void SetVolumeEnableState(bool newVolumeEnabledState);
  }
}