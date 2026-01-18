using Godot;
using System;

namespace Game
{
  public partial class Game : Node2D
  {
    [Export] private Timer _timer;

    public override void _Ready()
    {
      _timer = GetNode<Timer>("CarTimer");
      _timer.Timeout += _OnTimerTimeout;
    }

    private void _OnTimerTimeout()
    {
      // GD.Print("Timer timeout");
    }
  }
}
