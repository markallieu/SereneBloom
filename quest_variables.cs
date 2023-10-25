using Godot;
using System;

public partial class quest_variables : Node
{
	public int currentQuestLine = 1;
	public int warmGreetingProgress = 7;
	public int sycamore = 10;
	public int orchid = 2;
	public int marble = 50;

	public bool NecklaceQuestFinished = true;
	public bool StatueFinish = false;

	public bool IsQuestlineOneFinished(){
		return (warmGreetingProgress == 7 && StatueFinish && NecklaceQuestFinished);
	}

	public void startQuestlineTwo(){
		currentQuestLine = 2;
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
