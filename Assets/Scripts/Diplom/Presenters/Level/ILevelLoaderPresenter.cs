using Diplom.Entities.Level;

namespace Diplom.Presenters.Level
{
  public interface ILevelLoaderPresenter
  {
    void LoadLevel(LevelType levelType);
  }
}