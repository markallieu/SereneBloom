using Godot;
using System;

public partial class PauseOption : Control
{
	private Control PauseMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PauseMenu = GetParent().GetNode<Control>("PauseMenu");
		Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public  void _on_back_pressed(){
		Hide();
		PauseMenu.Show();
	}
	public void _on_fullscreen_checkbox_toggled(bool toggled){
		if(toggled){
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
		}else{
			DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
		}
	}
}
