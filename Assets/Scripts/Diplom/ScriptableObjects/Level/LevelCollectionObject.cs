using System;
using System.Collections.Generic;
using Diplom.Entities.Level;
using UnityEngine;

namespace Diplom.ScriptableObjects.Level
{
  [CreateAssetMenu(fileName = "LevelCollectionObject", menuName = "ScriptableObjects/LevelCollectionObject", order = 1)]
  public class LevelCollectionObject : ScriptableObject
  {
    [SerializeField] private List<LevelCollectionElement> _levelsCollection;
    public IReadOnlyList<LevelCollectionElement> LevelCollection => _levelsCollection;
  }

  [Serializable]
  public struct LevelCollectionElement
  {
    public LevelType LevelType;
    public int SceneID;
  }
}