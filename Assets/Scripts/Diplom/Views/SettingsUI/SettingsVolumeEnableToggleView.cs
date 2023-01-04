using Diplom.Presenters.Settings;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.SettingsUI
{
  [RequireComponent(typeof(Toggle))]
  public class SettingsVolumeEnableToggleView : MonoBehaviour
  {
    private Toggle _toggle;
    private ISettingsPresenter _presenter;

    [Inject]
    private void Construct(ISettingsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _toggle = GetComponent<Toggle>();
      _toggle.onValueChanged.AddListener(ToggleOnValueChanged);
      
      _presenter.IsVolumeEnabled.Subscribe(UpdateToggleValue).AddTo(this);
      UpdateToggleValue(_presenter.IsVolumeEnabled.Value);
    }

    private void UpdateToggleValue(bool newToggleValue)
    {
      _toggle.SetIsOnWithoutNotify(newToggleValue);
    }

    private void ToggleOnValueChanged(bool newToggleValue)
    {
      _presenter.SetVolumeEnableState(newToggleValue);
    }
  }
}