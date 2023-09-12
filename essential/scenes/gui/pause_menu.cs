using Godot;
using System;

public partial class pause_menu : Control
{
	private Control pauseOption;
	private AudioStreamPlayer2D clickSound;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
		pauseOption = GetParent().GetNode<Control>("PauseOption");
		clickSound =  GetNode<AudioStreamPlayer2D>("UI_SFX");
		clickSound.VolumeDb = 5;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("ui_cancel"))
        {
            
            //PauseMenu.Position = GetViewport().GetVisibleRect().Size / 2;
            //PauseMenu.SetPosition(GetViewportRect().Size / 2  );
            //PauseMenu.Position = GetViewportRect().Size / 2;
			if(!clickSound.Playing && !IsVisibleInTree()){
			clickSound.Play();
			}
			Show();
        }
	}

	public void _on_resume_pressed(){
		clickSound.Play();
		GetTree().Paused = false;
		Hide();
	}
	public void _on_option_pressed(){
		Hide();
		pauseOption.Show();
	}
	public void _on_quit_pressed(){
		GetTree().Quit();
	}
}
