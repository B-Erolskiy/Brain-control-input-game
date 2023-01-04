using Diplom.Entities.Level;

namespace Diplom.Usecases.Level
{
  public interface ILevelUsecase
  {
    Entities.Level.Level GetLevelByType(LevelType levelType);
  }
}