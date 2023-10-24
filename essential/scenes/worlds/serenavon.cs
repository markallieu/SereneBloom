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
        globals.firstGameLoad = false;
        Node2D player = GetNode<Node2D>("playerKaine");
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
