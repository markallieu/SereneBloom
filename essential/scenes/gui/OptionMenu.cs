using Godot;
using System;
using System.Runtime.InteropServices;

public partial class OptionMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public  void _on_back_pressed(){
		GetTree().ChangeSceneToFile("res://essential/scenes/gui/Menu.tscn");
	}

	public void _on_fullscreen_checkbox_toggled(bool toggled){
		if(toggled){
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
		}else{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		}
	}
}
