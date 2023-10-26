using Godot;
using System;

public partial class quest_variables : Node
{
	public bool isTalking = false;
	public int currentQuestLine = 2;
	public int warmGreetingProgress = 0;
	public int sycamore = 0;
	public int orchid = 0;
	public int marble = 0;

	// Questline 2

	public bool ManaAmbrosiaStart = false;

	public int lily = 0;
	public int rose = 0;
	public int crystal = 0;

	public bool NecklaceQuestFinished = false;
	public bool StatueFinish = false;
	public bool questline2_intro_played = false;
	public bool IsQuestlineOneFinished(){
		return (warmGreetingProgress >= 7 && StatueFinish && NecklaceQuestFinished);
	}

	public void startQuestlineTwo(){
		currentQuestLine = 2;
		GD.Print("Questline 2 started");
		GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");

	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
