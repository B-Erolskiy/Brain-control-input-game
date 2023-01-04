namespace Diplom.Entities.BrainStats
{
  public class BrainStats
  {
    /// <summary>
    /// Percentage of how much the user is focused
    /// </summary>
    public int ConcentrationPercent { get; set; }
    
    /// <summary>
    /// Percentage of how much the user is relaxed, meditated (high alpha)
    /// </summary>
    public int MeditationPercent { get; set; }
    
    /// <summary>
    /// In milliseconds
    /// </summary>
    public double ServerPing { get; set; }
  }
}