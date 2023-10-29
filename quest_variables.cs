using Godot;
using System;
using System.IO;

public partial class quest_variables : Node
{
	public string savePath = "user://variable.save";
	public bool isTalking = false;
	public int currentQuestLine = 1;
	public int warmGreetingProgress = 0;
	public int sycamore = 0;
	public int orchid = 0;
	public int marble = 0;


	// Questline 2

	public bool KravonAfterTutorialDialogStart = false;
	public bool ManaAmbrosiaStart = false;


	public int lily = 0;
	public bool lilyJustFinished = false;
	public bool lilyHidden = false;
	public int rose = 0;
	public bool roseFinished = false;
	public bool roseStarted = false;
	public bool rosePickedUp = false;
	public bool poemShowed = false;
	public int tombChosen = 0;
	public int trueTombChosen = 0;
	public int crystal = 0;
	public bool crystalJustFInished = false;

	public bool boulderDestroyed = false;
	public bool NecklaceQuestFinished = false;
	public bool StatueFinish = false;
	public bool questline2_intro_played = false;
	public bool IsQuestlineOneFinished(){
		return (warmGreetingProgress >= 7 && StatueFinish && NecklaceQuestFinished);
	}
	public Vector2 position;
	public bool needToChangePosition = false;
	public bool AfterMinigame = false;

	public bool positionChanged = false;
	public void startQuestlineTwo(){
		currentQuestLine = 2;
		GD.Print("Questline 2 started");
		GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");

	}

	public void startQuestlineThree(){
		currentQuestLine = 3;
		GD.Print("Questline 3 started");
		GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");
	}

	public void save(){
		using var file = Godot.FileAccess.Open(savePath,Godot.FileAccess.ModeFlags.Write);
		file.StoreVar(currentQuestLine);
		file.StoreVar(position);
		file.StoreVar(warmGreetingProgress);
		file.StoreVar(sycamore);
		file.StoreVar(orchid);
		file.StoreVar(marble);
		file.StoreVar(ManaAmbrosiaStart);
		file.StoreVar(lily);
		file.StoreVar(rose);
		file.StoreVar(crystal);
		file.StoreVar(NecklaceQuestFinished);
		file.StoreVar(StatueFinish);
		file.StoreVar(questline2_intro_played);;
		file.StoreVar(lilyHidden);
		file.StoreVar(lilyJustFinished);
		file.StoreVar(roseFinished);
		file.StoreVar(roseStarted);
		file.StoreVar(rosePickedUp);
		file.StoreVar(crystalJustFInished);
		file.StoreVar(boulderDestroyed);
		file.StoreVar(globals.currentScene);
		file.StoreVar(globals.firstSerenavonLoad);
		file.StoreVar(globals.firstSerenavonLoad);
	}

	public void load(){
		using var file = Godot.FileAccess.Open(savePath,Godot.FileAccess.ModeFlags.Read);
		currentQuestLine = (int)file.GetVar(false);
		position = (Vector2)file.GetVar(false);
		GD.Print(position);
		warmGreetingProgress = (int)file.GetVar(false);
		sycamore = (int)file.GetVar(false);
		orchid = (int)file.GetVar(false);
		marble = (int)file.GetVar(false);
		ManaAmbrosiaStart = (bool)file.GetVar(false);
		lily = (int)file.GetVar(false);
		rose = (int) file.GetVar(false);
		crystal = (int) file.GetVar(false);
		NecklaceQuestFinished = (bool)file.GetVar(false);
		StatueFinish = (bool) file.GetVar(false);
		questline2_intro_played = (bool) file.GetVar(false);
		lilyHidden = (bool) file.GetVar(false);
		lilyJustFinished = (bool) file.GetVar(false);
		roseFinished = (bool) file.GetVar(false);
		roseStarted = (bool) file.GetVar(false);
		rosePickedUp = (bool) file.GetVar(false);
		crystalJustFInished = (bool) file.GetVar(false);
		boulderDestroyed = (bool) file.GetVar(false);
		globals.currentScene = (string) file.GetVar(false);
		globals.firstSerenavonLoad = (bool) file.GetVar(false);
		globals.firstSerenavonLoad = (bool) file.GetVar(false);
		needToChangePosition = true;
		positionChanged = true;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
