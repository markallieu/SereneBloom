using Godot;
using System;

public partial class questline2_intro2 : CanvasLayer
{
	private AnimationPlayer animation;
	quest_variables questVar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		if(questVar.currentQuestLine == 2 && !questVar.questline2_intro_played){
		GD.Print("questline2 text played");
		Show();
		animation = GetNode<AnimationPlayer>("anim");
		animation.Play("Show text");
		questVar.questline2_intro_played = true;
		}
		GD.Print("test");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
}
