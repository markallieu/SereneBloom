using Godot;
using System;

public partial class UI : CanvasLayer
{
	Panel notif;
	AnimationPlayer anim;
	public RichTextLabel notifText;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		notif = GetNode<Panel>("Notif");
		notifText = GetNode<RichTextLabel>("Notif/RichTextLabel");
		notif.Hide();
		anim = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public async void GlobalNotif(string text){
        notifText.Text = text;
		GD.Print("runned");
		notif.Show();
		anim.Play("NotifEnter");
		await ToSignal(GetTree().CreateTimer(2), "timeout");
		anim.Play("NotifExit");
		notif.Hide();
    }
}
