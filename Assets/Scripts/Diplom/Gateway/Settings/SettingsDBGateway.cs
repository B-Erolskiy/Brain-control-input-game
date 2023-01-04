using UnityEngine;

namespace Diplom.Gateway.Settings
{
  public class SettingsDBGateway : ISettingsDBGateway
  {
    private readonly Entities.Settings.Settings _settings;

    public SettingsDBGateway()
    {
      _settings = GetSettingsFromSave() ?? new Entities.Settings.Settings();
    }

    public float GetTotalVolume() => _settings.TotalVolume;

    public void SetTotalVolume(float newTotalVolumeValue)
    {
      _settings.TotalVolume = newTotalVolumeValue;
      SaveSettingsToPrefs();
    }

    public bool GetVolumeEnableState() => _settings.IsVolumeEnabled;

    public void SetVolumeEnabledState(bool newVolumeEnabledValue)
    {
      _settings.IsVolumeEnabled = newVolumeEnabledValue;
      SaveSettingsToPrefs();
    }

    #region Save to local prefs

    private Entities.Settings.Settings GetSettingsFromSave()
    {
      var json = PlayerPrefs.GetString("Settings");
      var settingsPrefsDTO = JsonUtility.FromJson<SettingsPrefsDTO>(json);
      if (settingsPrefsDTO == null) return null;

      var savedSettings = new Entities.Settings.Settings
      {
        TotalVolume = settingsPrefsDTO.TotalVolume,
        IsVolumeEnabled = settingsPrefsDTO.IsVolumeEnabled
      };
      
      return savedSettings;
    }

    private void SaveSettingsToPrefs()
    {
      var settingsPrefsDTO = new SettingsPrefsDTO
      {
        TotalVolume = _settings.TotalVolume,
        IsVolumeEnabled = _settings.IsVolumeEnabled
      };
      var json = JsonUtility.ToJson(settingsPrefsDTO);
      PlayerPrefs.SetString("Settings", json);
    }

    #endregion
  }
}