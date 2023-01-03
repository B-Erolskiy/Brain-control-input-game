namespace Diplom.Entities
{
  public class Level
  {
    public LevelType LevelType { get; set; }
    public int SceneID { get; set; }
  }

  public enum LevelType
  {
    Menu,
    LevelEasy,
    LevelHard
  }
}