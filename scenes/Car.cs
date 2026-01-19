using Godot;
using System;

namespace Car
{
  public partial class Car : Area2D
  {
    public Vector2 direction = Vector2.Left;
    public int speed = 1;

    public override void _Process(double delta)
    {
      Position += direction * speed;
    }

    private void _OnCarScreenExited()
    {
      GD.Print("Car destroyed");
      QueueFree();
    }
  }
}
