using Diplom.Entities.Level;
using Diplom.Usecases.Level;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Diplom.Presenters.Level
{
  public class LevelLoaderPresenter : ILevelLoaderPresenter
  {
    private readonly ILevelUsecase _usecase;

    public LevelLoaderPresenter(ILevelUsecase usecase)
    {
      _usecase = usecase;
    }
    
    public void LoadLevel(LevelType levelType)
    {
      var level = _usecase.GetLevelByType(levelType);
      if (level == null)
      {
        Debug.LogError($"Don`t find level with type: {levelType:G}");
        return;
      }

      var levelSceneID = level.SceneID;
      SceneManager.LoadScene(levelSceneID);
    }

    public void ReloadCurrentLevel()
    {
      var activeScene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(activeScene.buildIndex);
    }
  }
}