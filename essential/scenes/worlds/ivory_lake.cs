using Godot;
using System;

public partial class ivory_lake : Node2D
{
    quest_variables questVar;
    CharacterBody2D sigorius;
    CharacterBody2D eleanor;
    Area2D necklace;
    Area2D lily;
    public override void _Ready()
    {
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        lily = GetNode<Area2D>("Area2D2");
        globals.currentScene = "ivory_lake";
        Node2D player = GetNode<Node2D>("playerKaine");
        if(!questVar.positionChanged){
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionIvoryLake = new Vector2(globals.PlayerStartIvoryLakeX, globals.PlayerStartIvoryLakeY);
            player.Position = newPositionIvoryLake;
        }
        }else{
            questVar.positionChanged = false;
        }
        sigorius = GetNode<CharacterBody2D>("Sigorius");
        eleanor = GetNode<CharacterBody2D>("Eleanor");
        if(questVar.currentQuestLine > 1){
        sigorius.Hide();
        eleanor.Hide();
        }
        necklace = GetNode<Area2D>("Area2D");
        if(questVar.currentQuestLine > 1){
            necklace.Hide();
        }
        if(questVar.lilyHidden){
            lily.Hide();
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
