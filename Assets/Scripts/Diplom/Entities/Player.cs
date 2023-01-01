using System;

namespace Diplom.Entities
{
  public class Player
  {
    public float ForwardSpeed { get; set; } = 5f;
    public float HorizontalSpeed { get; set; } = 4f;
    public float HorizontalMovement { get; set; }
    public float Progress { get; set; }
    public float Health { get; set; } = 10f;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsDead { get; set; }
  }
}