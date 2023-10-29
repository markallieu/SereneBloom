using Godot;
using System;

public partial class magic_complete4 : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_animation_player_animation_finished(StringName s){
	}

	public async void backHome(){
		await ToSignal(GetTree().CreateTimer(22), "timeout");
		GetTree().ChangeSceneToFile("res://essential/scenes/gui/Menu.tscn");
	}
}
