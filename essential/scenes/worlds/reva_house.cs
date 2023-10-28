using Godot;
using System;

public partial class reva_house : Node2D
{
    quest_variables questVar;
    public override void _Ready()
    {
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        globals.currentScene = "reva_house";
        Node2D player = GetNode<Node2D>("playerKaine");
        if(!questVar.positionChanged){
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionRevaHouse = new Vector2(globals.PlayerStartRevaHouseX, globals.PlayerStartRevaHouseY);
            player.Position = newPositionRevaHouse;
        }
        }else{
            questVar.positionChanged = false;
        }
    }

    public override void _Process(double delta)
    {
        ChangeScene();
    }

    public void _on_reva_house_exitpoint_body_entered(Node2D body)
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
                globals.firstRevaHouseLoad = false;
                globals.FinishChangeScene();
            }
        }
    }
}
