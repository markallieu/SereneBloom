using Godot;
using System;

public partial class poem_quest : CanvasLayer
{
	private AnimationPlayer animation;
	private CollisionShape2D noteColl;
	quest_variables questVar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		noteColl = GetParent().GetNode<Area2D>("Area2D14").GetNode<CollisionShape2D>("CollisionShape2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("interact") && questVar.poemShowed)
        {
			GD.Print("POEM HIDDEN");
			Hide();
			Timer();
			questVar.poemShowed = false;
        }
	}
	async void Timer(){
		await ToSignal(GetTree().CreateTimer(2), "timeout");
		noteColl.Disabled = false;
	}
}
