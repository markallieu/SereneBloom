using Godot;
using System;

public partial class dialogic : Node2D
{
	private GDScript dialogics;
    private GodotObject dialogicNode; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dialogics = (GDScript)GD.Load("res://addons/dialogic/Other/DialogicGameHandler.gd");
        dialogicNode = (GodotObject) dialogics.New();
        AddChild((Node) dialogicNode);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void _on_area_2d_kravon_body_entered(Node2D node){
		GD.Print("entered");
		dialogicNode.Call("start","Quest1Kravon");
	}
}
