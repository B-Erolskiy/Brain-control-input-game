using Diplom.Presenters.Settings;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.SettingsUI
{
  [RequireComponent(typeof(Slider))]
  public class SettingsTotalVolumeSliderView : MonoBehaviour
  {
    private Slider _slider;
    private ISettingsPresenter _presenter;

    [Inject]
    private void Construct(ISettingsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _slider = GetComponent<Slider>();
      _slider.onValueChanged.AddListener(SliderOnValueChanged);

      _presenter.IsVolumeEnabled.Subscribe(UpdateSliderInteractableState).AddTo(this);
      _presenter.TotalVolume.Subscribe(UpdateSliderValue).AddTo(this);
    }

    private void UpdateSliderInteractableState(bool interactable)
    {
      _slider.interactable = interactable;
    }

    private void UpdateSliderValue(float newSliderValue)
    {
      _slider.SetValueWithoutNotify(newSliderValue);
    }

    private void SliderOnValueChanged(float newSliderValue)
    {
      _presenter.SetTotalVolume(newSliderValue);
    }
  }
}