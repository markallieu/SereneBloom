using Godot;
using System;

public partial class VortenRose : Area2D
{
	Label text;
	Sprite2D necklace;

	UI ui;
	private Node2D dialogic;
	bool inside = false;
	quest_variables questVar;

	public override void _Ready()
	{
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		text = GetNode<Label>("Label");
		necklace = GetNode<Sprite2D>("Sprite2D");
		ui = GetParent<Node2D>().GetNode<UI>("CanvasLayer");
		text.Hide();
		dialogic = GetNode<Node2D>("dialogic");
		if(questVar.roseFinished){
			Show();
		}
		if(questVar.rosePickedUp){
			Hide();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("interact") && inside && IsVisibleInTree())
        {
			necklace.Hide();
			text.Hide();
			questVar.rose = 1 ;
			ui.ManaAmbrosia();
        }
	}

	public void _on_body_entered(Node2D node){
		if( node.IsInGroup("player") && questVar.roseFinished){
			text.Show();
			inside = true;
			questVar.rosePickedUp = true;
		}
	}
	public void _on_body_exited(Node2D node){
		text.Hide();
		inside = false;
	}
	
}
