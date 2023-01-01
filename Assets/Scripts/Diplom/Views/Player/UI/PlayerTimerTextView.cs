using System;
using Diplom.Presenters.Player;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.UI
{
  public class PlayerTimerTextView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _timeText;

    private DateTime _startTime;
    private bool _isTimerActive = true;
    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _presenter.StartTime.Subscribe(UpdateStartTime).AddTo(this);
      _presenter.EndTime.Subscribe(endTime =>
      {
        if (endTime != default) StopTimer();
      }).AddTo(this);

      Observable.EveryUpdate().Subscribe(_ => UpdateTimer()).AddTo(this);
    }

    private void UpdateStartTime(DateTime startTime)
    {
      _startTime = startTime;
    }

    private void StopTimer()
    {
      _isTimerActive = false;
    }

    private void UpdateTimer()
    {
      if (!_isTimerActive) return;
      
      _timeText.text = $"{DateTime.Now - _startTime:mm\\:ss}";
    }
  }
}