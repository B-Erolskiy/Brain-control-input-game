using System;

namespace Diplom.Gateway.BrainStats
{
  [Serializable]
  public class BrainStatsServerDTO
  {
    public int concentration;
    public int meditation;

    public override string ToString()
    {
      return $"Concentration: {concentration}\n" +
             $"Meditation: {meditation}";
    }
  }
}