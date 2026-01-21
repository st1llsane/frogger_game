using Godot;

namespace Game
{
  public partial class Game : Node2D
  {
    private PackedScene _carScene;
    private Node2D _carsNode;
    private Node2D _carStartPositionsNode;

    public override void _Ready()
    {
      _carScene = ResourceLoader.Load<PackedScene>("res://scenes/car.tscn");
      _carsNode = GetNode<Node2D>("Cars");
      _carStartPositionsNode = GetNode<Node2D>("CarStartPositions");
    }

    private void _OnCarTimerTimeout()
    {
      var car = _carScene.Instantiate() as Car.Car;
      var posMarker = _carStartPositionsNode.GetChildren().PickRandom() as Marker2D;

      car.Position = posMarker.Position;

      _carsNode.AddChild(car);
      car.Connect("body_entered", Callable.From<Node2D>(_OnBodyEntered));
    }

    private void _OnBodyEntered(Node2D body)
    {
      {
        GD.Print($"Body entered: {body}");
      }
    }
  }
}
