using System;
using System.Collections.Generic;
using Godot;

namespace Car
{
  public partial class Car : Area2D
  {
    public Sprite2D sprite;
    public Vector2 direction = Vector2.Left;
    public int speed = 160;
    private readonly List<Texture2D> colors = [
      ResourceLoader.Load<Texture2D>("res://graphics/cars/green.png"),
      ResourceLoader.Load<Texture2D>("res://graphics/cars/red.png"),
      ResourceLoader.Load<Texture2D>("res://graphics/cars/yellow.png")
      ];

    public override void _Ready()
    {
      sprite = GetNode<Sprite2D>("Sprite2D");

      if (Position.X <= 0)
      {
        direction = Vector2.Right;
        sprite.FlipH = true;
      }

      sprite.Texture = colors[new Random().Next(3)];
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
