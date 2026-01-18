using Godot;
using Frogger.shared;

namespace Player
{
  public partial class Player : CharacterBody2D
  {
    private AnimatedSprite2D _animatedSprite;

    public Vector2 direction = new(0, 0);
    public int speed = 180;

    public override void _Ready()
    {
      _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
      direction = Input.GetVector(
        InputKey.Left.Raw(),
        InputKey.Right.Raw(),
        InputKey.Up.Raw(),
        InputKey.Down.Raw()
      );
      // GD.Print($"DIRECTION: {direction}");

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
      if (direction.Length() <= 0)
      {
        _animatedSprite.Frame = 0;
        return;
      }

      if (direction.X != 0)
      {
        _animatedSprite.Animation = "left_right_walk";
        _animatedSprite.FlipH = direction.X > 0;
      }
      else
      {
        _animatedSprite.Animation = direction.Y > 0 ? "down_walk" : "up_walk";
        _animatedSprite.FlipH = direction.Y > 0;
      }
    }

    private void _OnBodyEntered(Node2D body)
    {
      GD.Print("Area entered");
    }
  }
}
