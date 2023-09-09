using Godot;
using System;

public partial class cliffside : Node2D
{
    public override void _Ready()
    {
        globals.currentScene = "cliffside";
    }

    public override void _Process(double delta)
    {
        ChangeScene();
    }

    public void _on_serenavon_transition_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true; 
        }
    }

    public void _on_serenavon_transition_point_body_exited(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = false;
        }
    }

    public void ChangeScene()
    {
        if (globals.transitionScene == true)
        {
            if (globals.currentScene == "cliffside")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");
                globals.FinishChangeScene(); 
            }
        }
    }
}
