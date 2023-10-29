using Godot;
using System;

public partial class magic_complete4 : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	Button quit;
	public override void _Ready()
	{
		quit = GetNode<Button>("Quit");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_animation_player_animation_finished(StringName s){
		quit.Show();
	}

	public void _on_quit_pressed(){
		GetTree().Quit();
	}
}
