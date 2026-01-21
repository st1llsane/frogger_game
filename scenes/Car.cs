using Godot;

namespace Car
{
  public partial class Car : Area2D
  {
    public Sprite2D sprite;
    public Vector2 direction = Vector2.Left;
    public int speed = 160;

    public override void _Ready()
    {
      sprite = GetNode<Sprite2D>("Sprite2D");

      if (Position.X <= 0)
      {
        direction = Vector2.Right;
        sprite.FlipH = true;
      }
    }

    public override void _Process(double delta)
    {
      Position += direction * speed * (float)delta;
    }

    private void _OnCarScreenExited()
    {
      QueueFree();
    }
  }
}
