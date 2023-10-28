using Godot;
using System;
using System.ComponentModel;

public partial class UI : CanvasLayer
{
	Panel notif;
	AnimationPlayer anim;
	
	Label notifTitle;
	Label notifDescription;
	
	CharacterBody2D kaine;
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
		kaine = GetParent().GetNode<CharacterBody2D>("playerKaine");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void saveGame(){
		GlobalNotif("Progres tersimpan!","Klik load untuk mengembalikan progres anda.");
		questVar.position = kaine.Position;
		questVar.save();
		dialogic.Call("saveDialogic");
		GD.Print("saved");
	}
	
	public void loadGame(){
		dialogic.Call("loadDialogic");
		questVar.load();
		GD.Print(globals.currentScene);
		GetTree().ChangeSceneToFile("res://essential/scenes/worlds/"  + globals.currentScene + ".tscn");
		GD.Print("loaded");

	}

	public void BuildingStatue(){
		GlobalNotif("Building a Statue",$"Sycamore Wood: ({questVar.sycamore}/10), Marble: ({questVar.marble}/50), Orchid: ({questVar.orchid}/2)");
		if(questVar.sycamore == 10 && questVar.marble == 50 && questVar.orchid ==2 ){
			GlobalNotif("Building a Statue","Barang terpenuhi! Segera berikan kepada Reva.");
			dialogic.Call("setBuildStatue");
		}
	}

	public void ManaAmbrosia(){
		GlobalNotif("Mana Ambrosia", $"Lily of the Lake:({questVar.lily}/1) Vorten Rose:({questVar.rose}/1) Mana Crystal:({questVar.crystal}/1)");
		if(questVar.lily == 1 && questVar.rose == 1 && questVar.crystal == 1 ){
			GlobalNotif("Mana Ambrosia","Bahan terpenuhi! Segera berikan kepada Aeiri.");
			dialogic.Call("setManaAmbriosa");
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
				questVar.NecklaceQuestFinished = true;
				GlobalNotif("Lost Jewelry","Quest Selesai!");
				break;
			case "StatueFinish":
				GlobalNotif("Building a Statue","Quest Selesai!");
				questVar.StatueFinish = true;
				break;
			case "ManaDisease":
				GlobalNotif("Mana Disease","Sembuhkan Heinrich yang terkena penyakit mana.");
				break;
			case "ManaAmbrosia":
				ManaAmbrosia();
				questVar.ManaAmbrosiaStart = true;
				break;
			case "ELeanorMagicGame":

				break;
			case "Lily":
				questVar.lily += 1;
				ManaAmbrosia();
				break;
			case "Rose":
				questVar.rose +=1;
				ManaAmbrosia();
				break;
			case "Crystal":
				questVar.crystal +=1;
				break;
			case "tutorialKravon":
				questVar.position = kaine.Position;
				questVar.isTalking = false;
				GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/tutorial_text.tscn");
				break;
		}
		if(questVar.IsQuestlineOneFinished() && questVar.currentQuestLine == 1){
			//timer(5);
			questVar.startQuestlineTwo();
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

	public void _on_timeline_ended(){
		questVar.isTalking = false;
	}

	async void timer(int second){
		await ToSignal(GetTree().CreateTimer(second), "timeout");
	}
	
}
