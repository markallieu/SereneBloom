using Godot;
using System;

public partial class LockedDoor : Area2D
{
	UI ui;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ui = GetParent().GetNode<UI>("CanvasLayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_body_entered(Node2D node){
		if(node is playerKaine){
		ui.GlobalNotif("Pintu dikunci.","Bangunan ini tidak dapat diakses.");
		}
	}
}
