using System;

namespace Diplom.Entities.Player
{
  public class Player
  {
    public float ForwardSpeed { get; set; } = 5f;
    public float HorizontalSpeed { get; set; } = 4f;
    public int Progress { get; set; }
    public int Health { get; set; } = 10;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsDead { get; set; }
  }
}