using Godot;
using System;


public partial class serenavon : Node2D
{
    private Node2D dialogic;
    quest_variables questVar;

    CharacterBody2D eleanor3;
    CharacterBody2D griselda3;
    CharacterBody2D kravon3;
    CharacterBody2D Reva3;
    CharacterBody2D Sigorius3;
    CharacterBody2D Thomas3;

    CharacterBody2D heinrich;

    CharacterBody2D kravon;
    CharacterBody2D aeiri;
    CharacterBody2D griselda;
    //private UI ui;
    public override void _Ready()
    {
        //ui = GetNode<UI>("CanvasLayer");
        //ui.GlobalNotif("test");
        dialogic = GetNode<Node2D>("dialogic");
        globals.currentScene = "serenavon";
        globals.firstGameLoad = false;
        Node2D player = GetNode<Node2D>("playerKaine");
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        if(!questVar.positionChanged){
        if (globals.firstSerenavonLoad == true)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerStartSerenavonX, globals.PlayerStartSerenavonY);
            player.Position = newPositionSerenavon;
        }
        else if (globals.firstThomasShopLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon3X, globals.PlayerExitSerenavon3Y);
            player.Position = newPositionSerenavon;
            globals.firstThomasShopLoad = true;
        }
        else if (globals.firstRevaHouseLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon4X, globals.PlayerExitSerenavon4Y);
            player.Position = newPositionSerenavon;
            globals.firstRevaHouseLoad = true;
        }
        else if (globals.firstSolaceLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon2X, globals.PlayerExitSerenavon2Y);
            player.Position = newPositionSerenavon;
            globals.firstSolaceLoad = true;
        }
        else if (globals.firstIvoryLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon1X, globals.PlayerExitSerenavon1Y);
            player.Position = newPositionSerenavon;
            globals.firstIvoryLoad = true;
        }
        else if (globals.firstTownhallLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon5X, globals.PlayerExitSerenavon5Y);
            player.Position = newPositionSerenavon;
            globals.firstTownhallLoad = true;
        }
        else
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerStartSerenavonX, globals.PlayerStartSerenavonY);
            player.Position = newPositionSerenavon;
        }
        }else{
            questVar.positionChanged = false;
        }
        if(questVar.KravonAfterTutorialDialogStart){
            GD.Print("KravonAfterTutorialDialog");
            dialogic.Call("dialog","KravonAfterTutorial");
            questVar.KravonAfterTutorialDialogStart = false;
        }
        // QUESTLINE 3
        kravon = GetNode<CharacterBody2D>("Kravon");
        aeiri = GetNode<CharacterBody2D>("Aeiri");
        griselda = GetNode<CharacterBody2D>("Griselda");
        eleanor3 = GetNode<CharacterBody2D>("Eleanor");
        griselda3 = GetNode<CharacterBody2D>("Griselda2");
        kravon3 = GetNode<CharacterBody2D>("Kravon2");
        Reva3 = GetNode<CharacterBody2D>("Reva");
        Sigorius3 = GetNode<CharacterBody2D>("Sigorius");
        Thomas3 = GetNode<CharacterBody2D>("Thomas");
        heinrich = GetNode<CharacterBody2D>("Heinrich");

        if(questVar.currentQuestLine == 3){
            kravon.Hide();
            aeiri.Hide();
            griselda.Hide();
            eleanor3.Show();
            griselda3.Show();
            kravon3.Show();
            Reva3.Show();
            Sigorius3.Show();
            Thomas3.Show();
            heinrich .Show();
            Vector2 kaineQ3_POS;
            kaineQ3_POS.X = 481;
            kaineQ3_POS.Y = 933;
            player.Position = kaineQ3_POS;
        }
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
    public void _on_thomas_shop_transition_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {

            globals.transitionScene = true;
            globals.targetScene = "thomas_shop";
        }
    }
    public void _on_reva_house_transition_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true;
            globals.targetScene = "reva_house";
        }
    }

    public void _on_townhall_transition_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true;
            globals.targetScene = "townhall";
        }
    }

    private void ChangeScene()
    {
        if (globals.transitionScene == true)
        {
            if (globals.targetScene == "cliffside")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/cliffside.tscn");
                globals.firstSerenavonLoad = false;
                globals.firstGameLoad = false;
            }
            else if (globals.targetScene == "ivory_lake")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/ivory_lake.tscn");
                globals.firstSerenavonLoad = false;
                globals.firstGameLoad = false;
            }
            else if (globals.targetScene == "solace_haven")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/solace_haven.tscn");
                globals.firstSerenavonLoad = false;
                globals.firstGameLoad = false;
            }
            else if (globals.targetScene == "thomas_shop")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/thomas_shop.tscn");
                globals.firstSerenavonLoad = false;
                globals.firstGameLoad = false;
            }
            else if (globals.targetScene == "reva_house")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/reva_house.tscn");
                globals.firstSerenavonLoad = false;
                globals.firstGameLoad = false;
            }
            else if (globals.targetScene == "townhall")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/townhall.tscn");
                globals.firstSerenavonLoad = false;
                globals.firstGameLoad = false;
            }
            globals.FinishChangeScene();
        }
    }
}
