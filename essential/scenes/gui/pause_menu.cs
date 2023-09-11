using Godot;
using System;

public partial class pause_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui_cancel"))
        {
            GetTree().Paused = true;
            //PauseMenu.Position = GetViewport().GetVisibleRect().Size / 2;
            //PauseMenu.SetPosition(GetViewportRect().Size / 2  );
            //PauseMenu.Position = GetViewportRect().Size / 2;
            Show();
        }
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
