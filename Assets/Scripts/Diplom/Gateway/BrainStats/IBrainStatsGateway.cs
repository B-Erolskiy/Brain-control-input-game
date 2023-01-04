using System;

namespace Diplom.Gateway.BrainStats
{
  public interface IBrainStatsGateway
  {
    IObservable<Entities.BrainStats.BrainStats> GetBrainStats();
  }
}