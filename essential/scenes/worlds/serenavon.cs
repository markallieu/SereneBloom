using Godot;
using System;


public partial class serenavon : Node2D
{
    private Node2D dialogic;
    //private UI ui;
    public override void _Ready()
    {
        //ui = GetNode<UI>("CanvasLayer");
        //ui.GlobalNotif("test");
        globals.currentScene = "serenavon";
        Node2D player = GetNode<Node2D>("playerKaine");
        if (globals.firstThomasShopLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon3X, globals.PlayerExitSerenavon3Y);
            player.Position = newPositionSerenavon;
        }
        else if (globals.firstRevaHouseLoad == false)
        {
            Vector2 newPositionSerenavon = new Vector2(globals.PlayerExitSerenavon4X, globals.PlayerExitSerenavon4Y);
            player.Position = newPositionSerenavon;
        }
        else if (globals.firstSolaceLoad == false)
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
            else if (globals.targetScene == "thomas_shop")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/thomas_shop.tscn");
                globals.firstGameLoad = false;
                globals.firstIvoryLoad = false;
                globals.firstSolaceLoad = false;
                globals.firstThomasShopLoad = false;
            }
            else if (globals.targetScene == "reva_house")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/reva_house.tscn");
                globals.firstGameLoad = false;
                globals.firstIvoryLoad = false;
                globals.firstSolaceLoad = false;
                globals.firstThomasShopLoad = false;
                globals.firstRevaHouseLoad = false;
            }
            globals.FinishChangeScene();
        }
    }
}
