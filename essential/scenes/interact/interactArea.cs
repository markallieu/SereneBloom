using Godot;
using System;

public partial class interactArea : Area2D
{
	[Export]
	string timeline = "Quest1Kravon";
	bool canInteract = true;
	bool inside = false;
	private GDScript dialogic;
    private GodotObject dialogicNode; 
	private Label label;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dialogic = (GDScript)GD.Load("res://addons/dialogic/Other/DialogicGameHandler.gd");
        dialogicNode = (GodotObject) dialogic.New();
        AddChild((Node) dialogicNode);
		label  = GetNode<Label>("Label");
		label.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("interact"))
        {
	        var dialog = (Node) dialogicNode.Call("start",timeline);	
	        AddChild(dialog);
			label.Hide();
        }
	}
	void _on_body_entered(Node2D node){
		if(canInteract && node.IsInGroup("player")){
			label.Show();
			inside = true;
			GD.Print(inside);
		}
	}
//	public override void _Input(InputEvent @event)
//{
//    if (@event.IsActionPressed("interact") && inside)
//    {
//		GD.Print("interacted");
//        var dialog = (Node) dialogicNode.Call("start","StartingTimeline");	
//        AddChild(dialog);
//		label.Hide();
//    }
//}
	void _on_body_exited(Node2D node){
		label.Hide();
		inside = false;
	}
}
