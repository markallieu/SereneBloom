using Godot;
using System;

public partial class Rock : Area2D
{
	Label text;
	Sprite2D rock;

	UI ui;
	private Node2D dialogic;
	bool inside = false;
	quest_variables questVar;
	CharacterBody2D kaine;
	CollisionShape2D coll;


	public override void _Ready()
	{
		text = GetNode<Label>("Label");
		rock = GetNode<Sprite2D>("Sprite2D");
		ui = GetParent<Node2D>().GetNode<UI>("CanvasLayer");
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		text.Hide();
		dialogic = GetNode<Node2D>("dialogic");
		kaine = GetParent().GetNode<CharacterBody2D>("playerKaine");
		coll = GetNode<CollisionShape2D>("CollisionShape2D");
		if(questVar.boulderDestroyed){
			Hide();
			coll.Disabled = true;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("interact") && inside)
        {
			text.Hide();
			questVar.position = kaine.Position;
			questVar.isTalking = false;
			GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/magic_minigame_boulder.tscn");
			//call Minigame
			//ui.GlobalNotif("Kalung Diambil!","Kembalikan kepada Eleanor untuk menyelesaikan quest!");
		
        }
	}

	public void _on_body_entered(Node2D node){
		if( node.IsInGroup("player")){
			text.Show();
			inside = true;
		}
	}
	public void _on_body_exited(Node2D node){
		text.Hide();
		inside = false;
	}
	
}
