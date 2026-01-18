using System;

namespace Frogger.shared
{
  public enum InputKey
  {
    Left,
    Right,
    Up,
    Down,
    Jump,
  }

  public static class InputKeyExtensions
  {
    public static string Raw(this InputKey key)
    {
      return key switch
      {
        InputKey.Left => "left",
        InputKey.Right => "right",
        InputKey.Up => "up",
        InputKey.Down => "down",
        InputKey.Jump => "jump",
        _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
      };
    }
  }
}
