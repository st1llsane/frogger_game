using System;
using Godot;

namespace GameOverlay
{
  public partial class GameOverlay : CanvasLayer
  {
    private Label _timeLabel;
    private double _seconds;
    private Timer _gameTimer;

    public override void _Ready()
    {
      _timeLabel = GetNode<Label>("GameTimeLabel");
      _gameTimer = GetNode<Timer>("GameTimer");

      _timeLabel.Text = "Game time: 0";
      _seconds = 0;
      _gameTimer.OneShot = false;
      _gameTimer.Timeout += _OnTimerTimeout;
      _gameTimer.Start();
    }

    public override void _Process(double delta)
    {
      // _timeLabel.Text = $"Game time: {Math.Round(_gameTimer.TimeLeft, 2)}";
      _timeLabel.Text = $"Game time:{_seconds}";
    }

    private void _OnTimerTimeout()
    {
      GD.Print("TIMEOUT");
      _seconds += 1;
    }
  }
}
