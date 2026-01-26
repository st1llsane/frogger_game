using Godot;

namespace Frogger.shared
{
  public static class SceneHelper
  {
    public static void ChangeToMainScreen(Node node)
    {
      node.GetTree().CallDeferred(SceneTree.MethodName.ChangeSceneToFile, "res://scenes/ui/main_screen.tscn");
    }
  }
}
