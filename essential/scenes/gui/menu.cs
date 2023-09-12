using Godot;
using System;
using System.Xml.Resolvers;

public partial class menu : Control
{
	private AudioStreamPlayer2D clickSound;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public  void _on_play_pressed(){
		GetTree().ChangeSceneToFile("res://essential/scenes/worlds/cliffside.tscn");
	}
	public  void _on_option_pressed(){
		GetTree().ChangeSceneToFile("res://essential/scenes/gui/OptionMenu.tscn");
	}
	public  void _on_quit_pressed(){
		GetTree().Quit();
	}
}
