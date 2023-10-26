using Godot;
using System;

public partial class Lily : Area2D
{
	Label text;
	Sprite2D necklace;

	UI ui;
	private Node2D dialogic;
	bool inside = false;
	quest_variables questVar;


	public override void _Ready()
	{
		text = GetNode<Label>("Label");
		necklace = GetNode<Sprite2D>("Sprite2D");
		ui = GetParent<Node2D>().GetNode<UI>("CanvasLayer");
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		text.Hide();
		dialogic = GetNode<Node2D>("dialogic");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("interact") && inside)
        {
			necklace.Hide();
			text.Hide();
			ui.GlobalNotif("Kalung Diambil!","Kembalikan kepada Eleanor untuk menyelesaikan quest!");
			dialogic.Call("setNecklace");
        }
	}

	public void _on_body_entered(Node2D node){
		if( node.IsInGroup("player") && questVar.ManaAmbrosiaStart){
			text.Show();
			inside = true;
		}
	}
	public void _on_body_exited(Node2D node){
		text.Hide();
		inside = false;
	}
	
}
