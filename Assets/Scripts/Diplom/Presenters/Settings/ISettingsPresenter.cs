using UniRx;

namespace Diplom.Presenters.Settings
{
  public interface ISettingsPresenter
  {
    IReadOnlyReactiveProperty<float> TotalVolume { get; }
    IReadOnlyReactiveProperty<bool> IsVolumeEnabled { get; }

    void SetTotalVolume(float newTotalVolumeValue);
    void SetVolumeEnableState(bool newVolumeEnableValue);
  }
}