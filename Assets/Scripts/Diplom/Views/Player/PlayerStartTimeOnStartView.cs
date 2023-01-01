using System;
using Diplom.Presenters.Player;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player
{
  public class PlayerStartTimeOnStartView : MonoBehaviour
  {
    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _presenter.SetStartTime(DateTime.Now);
    }
  }
}