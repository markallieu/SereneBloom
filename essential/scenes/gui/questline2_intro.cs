using Godot;
using System;

public partial class Questline2_intro : CanvasLayer
{
	private AnimationPlayer animation;
	quest_variables questVar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		Hide();
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		if(questVar.currentQuestLine == 2){
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
		
	}
}
