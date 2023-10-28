using Godot;
using System;

public partial class townhall : Node2D
{
    quest_variables questVar;
    CharacterBody2D sigorius;
    CharacterBody2D eleanor;
    CharacterBody2D bed;
    CharacterBody2D emptyBed;

    public override void _Ready()
    {
        bed = GetNode<CharacterBody2D>("Bed");
        emptyBed = GetNode<CharacterBody2D>("Bed2");
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        globals.currentScene = "townhall";
        Node2D player = GetNode<Node2D>("playerKaine");
        if(!questVar.positionChanged){
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionTownhall = new Vector2(globals.PlayerStartTownhallX, globals.PlayerStartTownhallY);
            player.Position = newPositionTownhall;
        }
        }else{
            questVar.positionChanged = false;
        }
        sigorius = GetNode<CharacterBody2D>("Sigorius");
        eleanor = GetNode<CharacterBody2D>("Eleanor");
        sigorius.Hide();
        eleanor.Hide();
        if (questVar.currentQuestLine == 2){
            sigorius.Show();
            eleanor.Show();
            bed.Show();
            emptyBed.Hide();
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


