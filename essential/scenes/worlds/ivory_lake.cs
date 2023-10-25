using Godot;
using System;

public partial class ivory_lake : Node2D
{
    quest_variables questVar;
    CharacterBody2D sigorius;
    CharacterBody2D eleanor;
    public override void _Ready()
    {
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        globals.currentScene = "ivory_lake";
        Node2D player = GetNode<Node2D>("playerKaine");
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionIvoryLake = new Vector2(globals.PlayerStartIvoryLakeX, globals.PlayerStartIvoryLakeY);
            player.Position = newPositionIvoryLake;
        }
        sigorius = GetNode<CharacterBody2D>("Sigorius");
        eleanor = GetNode<CharacterBody2D>("Eleanor");
        if(questVar.currentQuestLine == 2){
        sigorius.Hide();
        eleanor.Hide();
        }
    }

    public override void _Process(double delta)
    {
        ChangeScene();
    }

    public void _on_ivory_lake_exit_point_body_entered(Node2D body)
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
                globals.firstIvoryLoad = false;
                globals.FinishChangeScene();
            }
        }
    }
}
