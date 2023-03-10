using Diplom.Entities.Level;
using Diplom.Presenters.Level;
using UnityEditor;

#if !UNITY_EDITOR
using UnityEngine;
#endif

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

    public void StartEasyLevel()
    {
      _levelLoaderPresenter.LoadLevel(LevelType.LevelEasy);
    }

    public void StartHardLevel()
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