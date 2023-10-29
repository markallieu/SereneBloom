using Godot;
using System;

public partial class TrueTomb : Area2D
{
	Label text;
	Sprite2D tomb;

	UI ui;
	bool inside = false;
	public bool chosen = false;
	solace_haven solaceHeaven;
	quest_variables questVar;

	public override void _Ready()
	{
		text = GetNode<Label>("Label");
		tomb = GetNode<Sprite2D>("Sprite2D");
		ui = GetParent<Node2D>().GetNode<UI>("CanvasLayer");
		text.Hide();
		questVar = GetNode<quest_variables>("/root/QuestVariables");
		solaceHeaven = GetParent<solace_haven>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("interact") && inside)
        {
			text.Hide();
			questVar.tombChosen +=1;
			questVar.trueTombChosen +=1;
			chosen = true;
			if(questVar.trueTombChosen == 3){
				ui.GlobalNotif("Batu Nisan yang dipilih benar!", "Segera ambil Vorten Rose");
				solaceHeaven.showRose();
				questVar.roseStarted = false;
				questVar.roseFinished = true;
			}
			else if(questVar.tombChosen == 3 && questVar.trueTombChosen < 3){
				questVar.tombChosen = 0;
				questVar.trueTombChosen = 0;
				solaceHeaven.enable();
				ui.GlobalNotif("Batu Nisan yang dipilih salah!", "coba ulangi (0/3)!");
			}else {
				ui.GlobalNotif("Batu Nisan dipilih!","(" + questVar.tombChosen + "/3)");
			}
			inside = false;
        }
	}

	public void _on_body_entered(Node2D node){
		if( node.IsInGroup("player") && !chosen && questVar.roseStarted && !questVar.roseFinished){
			text.Show();
			inside = true;
		}
	}
	public void _on_body_exited(Node2D node){
		text.Hide();
		inside = false;
	}
	
}
