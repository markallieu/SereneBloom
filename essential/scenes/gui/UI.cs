using Godot;
using System;

public partial class UI : CanvasLayer
{
	Panel notif;
	AnimationPlayer anim;
	
	Label notifText;
	bool test = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		notif = GetNode<Panel>("Notif");
		notifText = GetNode<Label>("Notif/Label");
		notif.Hide();
		anim = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_dialogic_signal(string arg){
        GD.Print(arg);
		GlobalNotif("arg");
    }
	async void GlobalNotif(string text){
		_Ready();
        notifText.Text = text;
		notif.Show();
		anim.Play("NotifEnter");
		await ToSignal(GetTree().CreateTimer(3), "timeout");
		anim.Play("NotifExit");
		notif.Hide();
    }
	
}
