using Godot;
using System;

public partial class poem_quest : CanvasLayer
{
	private AnimationPlayer animation;
	quest_variables questVar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		if(globals.firstGameLoad){
		Show();
		animation = GetNode<AnimationPlayer>("anim");
		animation.Play("Show text");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("interact") && questVar.poemShowed)
        {
			GD.Print("POEM HIDDEN");
			Hide();
			questVar.poemShowed = false;
        }
	}
	public void _on_anim_animation_finished(string animName){
		globals.textPlayed = true;
	}
}
