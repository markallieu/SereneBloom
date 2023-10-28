using Godot;
using System;

public partial class thomas_shop : Node2D
{
    quest_variables questVar;
    CharacterBody2D thomas;
    public override void _Ready()
    {
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        globals.currentScene = "thomas_shop";
        Node2D player = GetNode<Node2D>("playerKaine");
        if(!questVar.positionChanged){
        if (globals.firstThomasShopLoad == true)
        {
            Vector2 newPositionThomasHouse = new Vector2(globals.PlayerStartThomasShopX, globals.PlayerStartThomasShopY);
            player.Position = newPositionThomasHouse;
        }
        }else{
            questVar.positionChanged = false;
        }
        thomas = GetNode<CharacterBody2D>("Thomas");
        if(questVar.currentQuestLine == 3){
            thomas.Hide();
        }
    }

    public override void _Process(double delta)
    {
        ChangeScene();
    }

    public void _on_thomas_shop_exitpoint_body_entered(Node2D body)
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
                globals.firstThomasShopLoad = false;
                globals.FinishChangeScene();
            }
        }
    }
}
