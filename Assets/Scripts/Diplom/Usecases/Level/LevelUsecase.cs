using Diplom.Entities.Level;
using Diplom.Gateway.Level;

namespace Diplom.Usecases.Level
{
  public class LevelUsecase : ILevelUsecase
  {
    private readonly ILevelDBGateway _gateway;
    
    public LevelUsecase(ILevelDBGateway gateway)
    {
      _gateway = gateway;
    }
    
    public Entities.Level.Level GetLevelByType(LevelType levelType)
    {
      var level = _gateway.GetLevelByType(levelType);
      return level;
    }
  }
}