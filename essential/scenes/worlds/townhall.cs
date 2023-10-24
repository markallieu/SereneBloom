using Godot;
using System;

public partial class townhall : Node2D
{
    public override void _Ready()
    {
        globals.currentScene = "townhall";
        Node2D player = GetNode<Node2D>("playerKaine");
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionTownhall = new Vector2(globals.PlayerStartTownhallX, globals.PlayerStartTownhallY);
            player.Position = newPositionTownhall;
        }
    }

    public override void _Process(double delta)
    {
        ChangeScene();
    }

    public void _on_townhall_exitpoint_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true;
            globals.targetScene = "serenavon";
        }
    }

    private void ChangeScene()
    {
        if (globals.transitionScene == true)
        {
            if (globals.targetScene == "serenavon")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");
                globals.firstGameLoad = false;
                globals.firstTownhallLoad = false;
                globals.FinishChangeScene();
            }
        }
    }
}


