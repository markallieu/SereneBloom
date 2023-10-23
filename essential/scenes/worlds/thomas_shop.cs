using Godot;
using System;

public partial class thomas_shop : Node2D
{
    public override void _Ready()
    {
        globals.currentScene = "thomas_house";
        Node2D player = GetNode<Node2D>("playerKaine");
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionThomasHouse = new Vector2(globals.PlayerStartThomasShopX, globals.PlayerStartThomasShopY);
            player.Position = newPositionThomasHouse;
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
                globals.firstGameLoad = false;
                globals.firstThomasShopLoad = false;
                globals.FinishChangeScene();
            }
        }
    }
}
