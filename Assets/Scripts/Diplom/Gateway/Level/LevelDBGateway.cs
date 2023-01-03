using System.Collections.Generic;
using System.Linq;
using Diplom.Entities;
using Diplom.ScriptableObjects;
using Diplom.ScriptableObjects.Level;

namespace Diplom.Gateway.Level
{
  public class LevelDBGateway : ILevelDBGateway
  {
    private readonly List<Entities.Level> _levels;

    public LevelDBGateway(LevelCollectionObject levelCollectionObject)
    {
      _levels = new List<Entities.Level>();
      var levelCollectionElements = levelCollectionObject.LevelCollection;
      foreach (var levelCollectionElement in levelCollectionElements)
      {
        _levels.Add(new Entities.Level
        {
          LevelType = levelCollectionElement.LevelType,
          SceneID = levelCollectionElement.SceneID
        });
      }
    }

    public Entities.Level GetLevelByType(LevelType levelType) => _levels.FirstOrDefault(level => level.LevelType == levelType);
  }
}