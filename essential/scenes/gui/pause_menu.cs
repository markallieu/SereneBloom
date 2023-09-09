using Godot;
using System;

public partial class pause_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_resume_pressed(){
		GetTree().Paused = false;
		Hide();
	}
	public void _on_option_pressed(){
		GetTree().ChangeSceneToFile("res://essential/scenes/gui/PauseOption.tscn");	
	}
	public void _on_quit_pressed(){
		GetTree().Quit();
	}
}
