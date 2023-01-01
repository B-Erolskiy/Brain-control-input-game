using System;
using Diplom.Usecases.Player;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Diplom.Presenters.PlayerUI
{
  public class PlayerUIPresenter : IPlayerUIPresenter, IDisposable
  {
    public const int MenuSceneID = 0;
    public const int GameSceneID = 1;
    
    public IReadOnlyReactiveProperty<bool> IsInGameScreenActive => _isInGameScreenActive;
    private readonly ReactiveProperty<bool> _isInGameScreenActive = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsSettingsScreenActive => _isSettingsScreenActive;
    private readonly ReactiveProperty<bool> _isSettingsScreenActive = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsLoseScreenActive => _isLoseScreenActive;
    private readonly ReactiveProperty<bool> _isLoseScreenActive = new ReactiveProperty<bool>();
    public IReadOnlyReactiveProperty<bool> IsPauseScreenActive => _isPauseScreenActive;
    private readonly ReactiveProperty<bool> _isPauseScreenActive = new ReactiveProperty<bool>();
    
    private IPlayerUsecase _usecase;
    private IDisposable _playerSubscribe;
    
    public void Initialize(IPlayerUsecase usecase)
    {
      _usecase = usecase;

      _playerSubscribe = _usecase.Player.Subscribe(UpdatePlayerData);

      UpdatePlayerData(_usecase.Player.Value);
      
      ClosePauseScreen();
      CloseLoseScreen();
      CloseSettingsScreen();
      
      OpenInGameScreen();
    }

    private void UpdatePlayerData(Entities.Player player)
    {
      if (!player.IsDead || _isLoseScreenActive.Value) return;
      
      OpenLoseScreen();
      CloseInGameScreen();
    }

    #region Public methods

    public void OpenSettingsScreen()
    {
      _isSettingsScreenActive.SetValueAndForceNotify(true);
    }

    public void CloseSettingsScreen()
    {
      _isSettingsScreenActive.SetValueAndForceNotify(false);
    }

    public void OpenPauseScreen()
    {
      Time.timeScale = 0;
      _isPauseScreenActive.SetValueAndForceNotify(true);
    }

    public void ClosePauseScreen()
    {
      Time.timeScale = 1;
      _isPauseScreenActive.SetValueAndForceNotify(false);
    }

    public void OpenLoseScreen()
    {
      Time.timeScale = 0;
      _isLoseScreenActive.SetValueAndForceNotify(true);
    }

    public void CloseLoseScreen()
    {
      Time.timeScale = 1;
      _isLoseScreenActive.SetValueAndForceNotify(false);
    }

    public void QuitGame()
    {
      SceneManager.LoadSceneAsync(MenuSceneID);
    }

    public void ReplayGame()
    {
      Time.timeScale = 1;
      SceneManager.LoadSceneAsync(GameSceneID);
    }

    public void OpenInGameScreen()
    {
      _isInGameScreenActive.SetValueAndForceNotify(true);
    }

    public void CloseInGameScreen()
    {
      _isInGameScreenActive.SetValueAndForceNotify(false);
    }

    public void Dispose()
    {
      _isInGameScreenActive?.Dispose();
      _isSettingsScreenActive?.Dispose();
      _isLoseScreenActive?.Dispose();
      _isPauseScreenActive?.Dispose();
      _playerSubscribe?.Dispose();
      _playerSubscribe?.Dispose();
    }
    
    #endregion
  }
}