using Godot;
using System;
using System.Xml.Resolvers;

public partial class menu : Control
{
	private AudioStreamPlayer2D clickSound;
	private Node2D dialogic;
	quest_variables questVar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		dialogic = GetNode<Node2D>("dialogic");
		questVar = GetNode<quest_variables>("/root/QuestVariables");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public  void _on_play_pressed(){
		GetTree().ChangeSceneToFile("res://essential/scenes/worlds/cliffside.tscn");
	}
	public  void _on_option_pressed(){
		GetTree().ChangeSceneToFile("res://essential/scenes/gui/OptionMenu.tscn");
	}

	public  void _on_load_pressed(){
		dialogic.Call("loadDialogic");
		questVar.load();
		GD.Print(globals.currentScene);
		GetTree().ChangeSceneToFile("res://essential/scenes/worlds/"  + globals.currentScene + ".tscn");
		GD.Print("loaded");
	}

	public  void _on_quit_pressed(){
		GetTree().Quit();
	}
}
