using Godot;
using System;

public partial class solace_haven : Node2D
{

    quest_variables questVar;
    Area2D rose;
    CanvasLayer poem;

    public override void _Ready()
    {
        globals.currentScene = "solace_haven";
        Node2D player = GetNode<Node2D>("playerKaine");
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        if(!questVar.positionChanged){
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionSolaceHaven = new Vector2(globals.PlayerStartSolaceHavenX, globals.PlayerStartSolaceHavenY);
            player.Position = newPositionSolaceHaven;
        }
        }
        rose = GetNode<Area2D>("Area2D13");
        poem = GetNode<CanvasLayer>("Poem");
    }

    public override void _Process(double delta)
    {
        ChangeScene();
    }

    public void _on_solace_haven_exit_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true;
            globals.targetScene = "serenavon";
        }
    }

    public void showRose(){
        rose.Show();
    }

    public void showPoem(){
        poem.Show();
        questVar.roseStarted = true;
    }
    private void ChangeScene()
    {
        if (globals.transitionScene == true)
        {
            if (globals.targetScene == "serenavon")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");
                globals.firstGameLoad = false;
                globals.firstIvoryLoad = false;
                globals.firstSolaceLoad = false;
                globals.FinishChangeScene();
            }
        }
    }
}
