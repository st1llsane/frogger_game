using Godot;
using Frogger.shared;

namespace Player
{
  public partial class Player : CharacterBody2D
  {
    private AnimatedSprite2D animatedSprite;

    public Vector2 direction = new(0, 0);
    public int speed = 180;

    public override void _Ready()
    {
      animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
      direction = Input.GetVector(
        InputKey.Left.Raw(),
        InputKey.Right.Raw(),
        InputKey.Up.Raw(),
        InputKey.Down.Raw()
      );

      Velocity = direction * speed;

      Animation();
      MoveAndSlide();

      if (Input.IsActionJustPressed(InputKey.Jump.Raw()))
      {
        GD.Print("Jump");
      }
    }

    private void Animation()
    {
      GD.Print($"DIRECTION: {direction}");
      if (direction.Length() <= 0)
      {
        animatedSprite.Frame = 0;
        return;
      }

      if (direction.X != 0)
      {
        animatedSprite.Animation = "left_right_walk";
        animatedSprite.FlipH = direction.X > 0;
      }
      else
      {
        animatedSprite.Animation = direction.Y > 0 ? "down_walk" : "up_walk";
        animatedSprite.FlipH = direction.Y > 0;
      }
    }
  }
}
