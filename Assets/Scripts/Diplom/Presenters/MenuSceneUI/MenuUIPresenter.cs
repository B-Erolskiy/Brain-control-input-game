using Diplom.Entities;
using Diplom.Presenters.Level;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Diplom.Presenters.MenuSceneUI
{
  public class MenuUIPresenter : IMenuUIPresenter
  {
    private readonly IMenuSceneUIPresenter _menuSceneUIPresenter;
    private readonly ILevelLoaderPresenter _levelLoaderPresenter;

    public MenuUIPresenter(IMenuSceneUIPresenter menuSceneUIPresenter, ILevelLoaderPresenter levelLoaderPresenter)
    {
      _menuSceneUIPresenter = menuSceneUIPresenter;
      _levelLoaderPresenter = levelLoaderPresenter;
    }
    
    public void StartGame()
    {
      _levelLoaderPresenter.LoadLevel(LevelType.LevelHard);
    }

    public void OpenSettings()
    {
      _menuSceneUIPresenter.OpenSettingsScreen();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPaused = true;
  #else
        Application.Quit();
  #endif
    }
  }
}