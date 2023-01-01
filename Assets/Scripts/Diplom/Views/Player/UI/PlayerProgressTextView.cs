using Diplom.Presenters.Player;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Diplom.Views.Player.UI
{
  public class PlayerProgressTextView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _progressText;
    
    private IPlayerStatsPresenter _presenter;
    
    [Inject]
    private void Construct(IPlayerStatsPresenter presenter)
    {
      _presenter = presenter;
    }
    
    private void Start()
    {
      _presenter.Progress.Subscribe(UpdateProgress).AddTo(this);
    }
    
    private void UpdateProgress(float newProgress)
    {
      _progressText.text = $"Progress: {newProgress}";
    }
  }
}