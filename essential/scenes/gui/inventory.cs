using Godot;
using System;

public partial class inventory : MarginContainer
{
	// Called when the node enters the scene tree for the first time.
	private Button inventoryTab;
	private Button questTab;
	private Label currentScene;

	private Node2D inventoryList;
	private Node2D currentQuest;
	public override void _Ready()
	{
		inventoryTab = GetNode<Button>("HBoxContainer/VBoxContainer/MarginContainer2/Panel2/InventoryTab");
		questTab = GetNode<Button>("HBoxContainer/VBoxContainer/MarginContainer2/Panel2/QuestTab");
		currentScene = GetNode<Label>("HBoxContainer/VBoxContainer/MarginContainer/Panel/CurrentScene");
		currentScene.Text = globals.currentScene;
		GD.Print(globals.currentScene);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("inventory"))
        {

            if(IsVisibleInTree()){
				Hide();
			}else{
				Show();
			}
        }
	}

	void _on_quest_tab_toggled(bool pressed){
		inventoryTab.ButtonPressed = false;
	}
	void _on_inventory_tab_toggled(bool pressed){
		questTab.ButtonPressed = false;
	}
}
