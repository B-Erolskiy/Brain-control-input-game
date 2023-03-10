using Diplom.Presenters.Player;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.UI
{
  [RequireComponent(typeof(TMP_Text))]
  public class PlayerResultTimeTextView : MonoBehaviour
  {
    private TMP_Text _text;
    private IPlayerStatsPresenter _presenter;

    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }

    private void Start()
    {
      _text = GetComponent<TMP_Text>();

      _presenter.IsDead.Where(isDead => isDead).Subscribe(_ => SetResultTime()).AddTo(this);
    }

    private void SetResultTime()
    {
      var resultTime = _presenter.GetResultTime();
      var formattedTime =
        $"{resultTime.Hours:D2}:{resultTime.Minutes:D2}:{resultTime.Seconds:D2}.{resultTime.Milliseconds:D3}";
      
      _text.text = $"Result time: {formattedTime}";
    }
  }
}