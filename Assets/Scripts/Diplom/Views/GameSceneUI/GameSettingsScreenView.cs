using Diplom.Presenters.PlayerUI;
using Diplom.Views.Base.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Diplom.Views.GameSceneUI
{
  public class GameSettingsScreenView : BaseScreenView
  {
    [SerializeField] private Button _hidePanelButton;
    
    private IPlayerUIPresenter _presenter; //todo change to settings presenter
    
    [Inject]
    private void Construct(IPlayerUIPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void Start()
    {
      _hidePanelButton.onClick.RemoveAllListeners();
      _hidePanelButton.onClick.AddListener(() => _presenter.CloseSettingsScreen());
      
      _presenter.IsSettingsScreenActive.Subscribe(OnScreenActiveStateChange).AddTo(this);
    }

    private void SetVolumeDisableValue(bool value)
    {
      var newVolumeEnabledValue = !value;
    }

    private void SetTotalVolumeValue(float value)
    {
      var newTotalVolumeValue = 0; //SettingsManager.Instance.IsVolumeEnabled ? value : 0;
      //SettingsManager.Instance.TotalVolume = newTotalVolumeValue;
    }
  }
}