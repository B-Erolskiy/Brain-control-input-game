using Diplom.Presenters.Player;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.UI
{
  public class PlayerStatsDisplayView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _healthValueText;
    [SerializeField] private TMP_Text _progressValueText;
    [SerializeField] private TMP_Text _speedValueText;

    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _presenter.Health.Subscribe(UpdateHealth).AddTo(this);
      _presenter.Progress.Subscribe(UpdateProgress).AddTo(this);
      _presenter.ForwardSpeed.Subscribe(UpdateForwardSpeed).AddTo(this);
    }

    private void UpdateHealth(int newHealth)
    {
      _healthValueText.text = newHealth.ToString();
    }
    
    private void UpdateProgress(int newProgress)
    {
      _progressValueText.text = newProgress.ToString();
    }
    
    private void UpdateForwardSpeed(float newSpeed)
    {
      _speedValueText.text = $"{newSpeed:F1}";
    }
  }
}