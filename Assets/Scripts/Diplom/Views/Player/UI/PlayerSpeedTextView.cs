using Diplom.Presenters.Player;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.UI
{
  public class PlayerSpeedTextView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _speedText;
    
    private IPlayerStatsPresenter _presenter;
    
    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void Start()
    {
      _presenter.ForwardSpeed.Subscribe(UpdateSpeed).AddTo(this);
    }
    
    private void UpdateSpeed(float newSpeed)
    {
      _speedText.text = $"Speed: {newSpeed}";
    }
  }
}