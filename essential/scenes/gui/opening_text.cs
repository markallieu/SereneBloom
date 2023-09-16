using Godot;
using System;

public partial class opening_text : CanvasLayer
{
	private AnimationPlayer animation;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(globals.firstGameLoad){
		Show();
		animation = GetNode<AnimationPlayer>("anim");
		animation.Play("Show text");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	
	}
	public void _on_anim_animation_finished(string animName){
		globals.textPlayed = true;
	}
}
