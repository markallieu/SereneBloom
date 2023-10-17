using Godot;
using System;


public partial class serenavon : Node2D
{
    private Node2D dialogic;
    private UI ui;
    public override void _Ready()
    {
        GD.Print("AAAA");
        ui = GetNode<UI>("CanvasLayer");
        ui.GlobalNotif("test");
        GD.Print("test");
        GD.Print(ui.notifText.Text);
        globals.currentScene = "serenavon";
        Node2D player = GetNode<Node2D>("playerKaine");
        if (globals.firstSolaceLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon2X, globals.PlayerExitSerenavon2Y);
            player.Position = newPositionSerenavon;
        }
        else if (globals.firstIvoryLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon1X, globals.PlayerExitSerenavon1Y);
            player.Position = newPositionSerenavon;
        }
        else if (globals.firstGameLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerStartSerenavonX, globals.PlayerStartSerenavonY);
            player.Position = newPositionSerenavon;
        }
        else
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerStartSerenavonX, globals.PlayerStartSerenavonY);
            player.Position = newPositionSerenavon;
        }
        dialogic = GetNode<Node2D>("dialogic");
        dialogic.Call("dialog","Quest1Aeiri");
    }

    public override void _Process(double delta)
    {
        ChangeScene();
    }

    public void _on_serenavon_exit_point_1_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true;
            globals.targetScene = "cliffside";


        }
    }

    public void _on_ivory_lake_transition_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true;
            globals.targetScene = "ivory_lake"; 
        }
    }

    public void _on_solace_haven_transition_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {

            globals.transitionScene = true;
            globals.targetScene = "solace_haven";
        }
    }

    private void ChangeScene()
    {
        if (globals.transitionScene == true)
        {
            if (globals.targetScene == "cliffside")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/cliffside.tscn");
                globals.firstGameLoad = false;
            }
            else if (globals.targetScene == "ivory_lake")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/ivory_lake.tscn");
                globals.firstGameLoad = false;
                globals.firstIvoryLoad = false;
            }
            else if (globals.targetScene == "solace_haven")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/solace_haven.tscn");
                globals.firstGameLoad = false;
                globals.firstIvoryLoad = false;
                globals.firstSolaceLoad = false;
            }
            globals.FinishChangeScene();
        }
    }
}
