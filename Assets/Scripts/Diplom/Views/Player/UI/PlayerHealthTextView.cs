using Diplom.Presenters.Player;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.UI
{
  public class PlayerHealthTextView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _healthText;
    
    private IPlayerStatsPresenter _presenter;
    
    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void Start()
    {
      _presenter.Health.Subscribe(UpdateHealth).AddTo(this);
    }

    private void UpdateHealth(float newHealth)
    {
      _healthText.text = $"Health: {newHealth}";
    }
  }
}