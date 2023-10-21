using Godot;
using System;

public partial class UI : CanvasLayer
{
	Panel notif;
	AnimationPlayer anim;
	
	Label notifTitle;
	Label notifDescription;
	bool test = true;

	public int warmGreetingProgress = 1;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		notif = GetNode<Panel>("Notif");
		notifTitle = GetNode<Label>("Notif/Title");
		notifDescription = GetNode<Label>("Notif/Description");
		notif.Hide();
		anim = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_dialogic_signal(string arg){
        GD.Print(arg);
		if(arg == "kravon1"){
			GlobalNotif("Warm Greetings (" + warmGreetingProgress.ToString() + "/7)","Berkenalanlah bersama semua penduduk Desa Serenavon.");
		}
    }
	async void GlobalNotif(string title,string description){
		_Ready();
		notifTitle.Text = title;
		notifDescription.Text = description;
		notif.Show();
		anim.Play("NotifEnter");
		await ToSignal(GetTree().CreateTimer(3), "timeout");
		anim.Play("NotifExit");
		notif.Hide();
    }
	
}
