using Diplom.Presenters.Input.Brain;
using Diplom.Views.Player.Movement;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.BrainStats
{
  public class BrainStatsDisplayView : MonoBehaviour
  {
    [Header("Concentration")]
    [SerializeField] private TMP_Text _concentrationValueText;
    [SerializeField] private ColorByNumberDisplayView _concentrationValueColoredView;
    [Header("Meditation")]
    [SerializeField] private TMP_Text _meditationValueText;
    [SerializeField] private ColorByNumberDisplayView _meditationValueColoredView;
    [SerializeField] private TMP_Text _serverPingText;
      
    private IBrainStatsPresenter _presenter;
    private int _concentrationPercent, _meditationPercent;

    [Inject]
    private void Construct(IBrainStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _presenter.ConcentrationPercent.Subscribe(UpdateConcentrationPercent).AddTo(this);
      _presenter.MeditationPercent.Subscribe(UpdateMeditationPercent).AddTo(this);
      _presenter.ServerPing.Subscribe(UpdateServerPing).AddTo(this);
      _presenter.AnalyseBrainActivityState.Subscribe(UpdateAnalyseBrainActivityState).AddTo(this);
    }

    private void UpdateAnalyseBrainActivityState(bool activityState)
    {
      if (activityState)
      {
        Show();
      }
      else
      {
        Hide();
        _concentrationPercent = 0;
        _meditationPercent = 0;
      }
    }

    private void UpdateConcentrationPercent(int concentrationPercent)
    {
      _concentrationPercent = concentrationPercent;
      UpdateMeditationAndConcentration();
    }

    private void UpdateMeditationPercent(int meditationPercent)
    {
      _meditationPercent = meditationPercent;
      UpdateMeditationAndConcentration();
    }

    private void UpdateServerPing(double serverPing)
    {
      _serverPingText.text = $"{serverPing:F1}";
    }

    private void UpdateMeditationAndConcentration()
    {
      _meditationValueText.text = _meditationPercent.ToString();
      _concentrationValueText.text = _concentrationPercent.ToString();
      
      _meditationValueColoredView.SetNumber(_meditationPercent, _concentrationPercent);
      _concentrationValueColoredView.SetNumber(_concentrationPercent, _meditationPercent);
    }

    #region Visibility

    private void Show()
    {
      gameObject.SetActive(true);
    }

    private void Hide()
    {
      gameObject.SetActive(false);
    }

    #endregion
  }
}