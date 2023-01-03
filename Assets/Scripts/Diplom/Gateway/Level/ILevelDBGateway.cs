using Diplom.Entities;

namespace Diplom.Gateway.Level
{
  public interface ILevelDBGateway
  {
    Entities.Level GetLevelByType(LevelType levelType);
  }
}