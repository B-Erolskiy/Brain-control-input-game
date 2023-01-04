using System.Collections.Generic;
using System.Linq;
using Diplom.Entities.Level;
using Diplom.ScriptableObjects.Level;

namespace Diplom.Gateway.Level
{
  public class LevelDBGateway : ILevelDBGateway
  {
    private readonly List<Entities.Level.Level> _levels;

    public LevelDBGateway(LevelCollectionObject levelCollectionObject)
    {
      _levels = new List<Entities.Level.Level>();
      var levelCollectionElements = levelCollectionObject.LevelCollection;
      foreach (var levelCollectionElement in levelCollectionElements)
      {
        _levels.Add(new Entities.Level.Level
        {
          LevelType = levelCollectionElement.LevelType,
          SceneID = levelCollectionElement.SceneID
        });
      }
    }

    public Entities.Level.Level GetLevelByType(LevelType levelType) => _levels.FirstOrDefault(level => level.LevelType == levelType);
  }
}