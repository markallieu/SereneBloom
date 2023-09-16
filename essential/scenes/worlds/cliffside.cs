using Godot;
using System;

public partial class cliffside : Node2D
{
    //Script dialogic = ResourceLoader.Load("res://addons/dialogic/Other/DialogicGameHandler.gd") as Script;
    private GDScript dialogic;
    private GodotObject dialogicNode; // This is a GodotObject
    private bool played = false;
    public override void _Ready()
    {
        globals.currentScene = "cliffside";
        Node2D player = GetNode<Node2D>("playerKaine");
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
        dialogic = (GDScript)GD.Load("res://addons/dialogic/Other/DialogicGameHandler.gd");
        dialogicNode = (GodotObject) dialogic.New();
        AddChild((Node) dialogicNode);
    }

    public override void _Process(double delta)
    {
        ChangeScene();
        if(globals.textPlayed && !played){
            var dialog = (Node) dialogicNode.Call("start","StartingTimeline");	
            AddChild(dialog);
            played = true;
        }
    }

    public void _on_serenavon_transition_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true; 
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
            if (globals.currentScene == "cliffside")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");
                globals.firstGameLoad = false;
                globals.FinishChangeScene(); 
            }
        }
    }
}
