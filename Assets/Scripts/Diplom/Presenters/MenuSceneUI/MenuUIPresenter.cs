using UnityEditor;
using UnityEngine.SceneManagement;

namespace Diplom.Presenters.MenuSceneUI
{
  public class MenuUIPresenter : IMenuUIPresenter
  {
    private IMenuSceneUIPresenter _menuSceneUIPresenter;
    
    public void Initialize(IMenuSceneUIPresenter menuSceneUIPresenter)
    {
      _menuSceneUIPresenter = menuSceneUIPresenter;
    }
    
    public void StartGame()
    {
      SceneManager.LoadSceneAsync(1);
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