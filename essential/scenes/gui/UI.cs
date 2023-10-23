using Godot;
using System;

public partial class UI : CanvasLayer
{
	Panel notif;
	AnimationPlayer anim;
	
	Label notifTitle;
	Label notifDescription;
	bool test = true;

	public int warmGreetingProgress = 0;
	quest_variables questVar;

	private Node2D dialogic;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		notif = GetNode<Panel>("Notif");
		notifTitle = GetNode<Label>("Notif/Title");
		notifDescription = GetNode<Label>("Notif/Description");
		notif.Hide();
		anim = GetNode<AnimationPlayer>("AnimationPlayer");
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		dialogic = GetNode<Node2D>("dialogic");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void BuildingStatue(){
		GlobalNotif("Building a Statue",$"Sycamore Wood: ({questVar.sycamore}/10), Marble: ({questVar.marble}/50), Orchid: ({questVar.orchid}/2)");
		if(questVar.sycamore == 10 && questVar.marble == 50 && questVar.orchid ==2 ){
			GlobalNotif("Building a Statue","Barang terpenuhi!, segera berikan kepada Reva.");
			dialogic.Call("setBuildStatue");
		}
	}

	public void _on_dialogic_signal(string arg){
        GD.Print(arg);
		
		switch(arg){
			case "WarmGreeting":
				questVar.warmGreetingProgress += 1;
				GlobalNotif("Warm Greetings (" + questVar.warmGreetingProgress.ToString() + "/7)","Berkenalanlah bersama semua penduduk Desa Serenavon.");
				break;
			case "BuildingStatue":
				BuildingStatue();
				break;
			case "Sycamore":
				questVar.sycamore = 10;
				BuildingStatue();
				break;
			case "Orchid":
				questVar.orchid = 2;
				BuildingStatue();
				break;
			case "Marble":
				questVar.marble = 50;
				BuildingStatue();
				break;
			case "LostJewelry":
				GlobalNotif("Lost Jewelry","Temukan kalung Eleanor yang ada di tebing kiri danau.");
				break;
			case "EndLostJewelry":
				GlobalNotif("Lost Jewelry","Quest Selesai!");
				break;
		}
    }
	public async void GlobalNotif(string title,string description){
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
