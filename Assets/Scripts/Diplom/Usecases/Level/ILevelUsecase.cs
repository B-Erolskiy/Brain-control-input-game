using Diplom.Entities;

namespace Diplom.Usecases.Level
{
  public interface ILevelUsecase
  {
    Entities.Level GetLevelByType(LevelType levelType);
  }
}