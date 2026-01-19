using Godot;

namespace Game
{
  public partial class Game : Node2D
  {
    private PackedScene _carScene;
    private Node2D _carsNode;

    public override void _Ready()
    {
      _carScene = ResourceLoader.Load<PackedScene>("res://scenes/car.tscn");
      _carsNode = GetNode<Node2D>("Cars");
    }

    private void _OnCarTimerTimeout()
    {
      GD.Print("Car spawned");
      var car = _carScene.Instantiate();
      _carsNode.AddChild(car);
    }
  }
}
