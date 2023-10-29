using Godot;
using System;

public partial class cliffside : Node2D
{
	private Node2D dialogic;
    private bool played = false;
    quest_variables questVar;
    public override void _Ready()
    {
        globals.currentScene = "cliffside";
        Node2D player = GetNode<Node2D>("playerKaine");
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        if(!questVar.positionChanged){
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionCliffiside = new Vector2(globals.PlayerStartCliffsideX, globals.PlayerStartCliffsideY);
            player.Position = newPositionCliffiside;
        }
        else if (globals.firstGameLoad == false)
        {
            Vector2 newPositionCliffiside = new Vector2(globals.PlayerExitCliffisideX, globals.PlayerExitCliffsideY);
            player.Position = newPositionCliffiside;
        }
        }
        else{
            questVar.positionChanged = false;
        }
        dialogic = GetNode<Node2D>("dialogic");
    }

    public override void _Process(double delta)
    {
        ChangeScene();
        if (globals.textPlayed && !played)
        {
            dialogic.Call("dialog","StartingTimeline");
            questVar.isTalking = true;
            played = true;
        }
    }

    public void _on_serenavon_transition_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true;
            globals.targetScene = "serenavon";
        }
    }

    public void _on_serenavon_transition_point_body_exited(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = false;
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
                globals.FinishChangeScene();
            }
        }
    }
}
