using Godot;
using System;

public partial class Notebook : Area2D
{
	Label text;
	Sprite2D necklace;

	UI ui;
	private Node2D dialogic;
	bool inside = false;
	quest_variables questVar;
	solace_haven solaceHeaven;

	public override void _Ready()
	{
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		text = GetNode<Label>("Label");
		necklace = GetNode<Sprite2D>("Sprite2D");
		ui = GetParent<Node2D>().GetNode<UI>("CanvasLayer");
		text.Hide();
		dialogic = GetNode<Node2D>("dialogic");
		solaceHeaven = GetParent<solace_haven>();
		if(!questVar.ManaAmbrosiaStart){
			Hide();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("interact") && inside && IsVisibleInTree() && !questVar.poemShowed)
        {
			text.Hide();
			solaceHeaven.showPoem();
			questVar.poemShowed = true;
			ui.ManaAmbrosia();
        }
	}

	public void _on_body_entered(Node2D node){
		if( node.IsInGroup("player")&& questVar.ManaAmbrosiaStart){
			text.Show();
			inside = true;
		}
	}
	public void _on_body_exited(Node2D node){
		text.Hide();
		inside = false;
	}
	
}
