using Diplom.Entities.Level;

namespace Diplom.Gateway.Level
{
  public interface ILevelDBGateway
  {
    Entities.Level.Level GetLevelByType(LevelType levelType);
  }
}