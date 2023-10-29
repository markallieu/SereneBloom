using Godot;
using System;

public partial class solace_haven : Node2D
{

    quest_variables questVar;
    Area2D rose;
    CanvasLayer poem;

    FakeTomb tomb1;
    FakeTomb tomb2;
    FakeTomb tomb3;
    FakeTomb tomb4;
    FakeTomb tomb5;
    FakeTomb tomb6;
    FakeTomb tomb7;
    FakeTomb tomb8;
    FakeTomb tomb9;
    TrueTomb tomb10;
    TrueTomb tomb11;
    TrueTomb tomb12;

    public override void _Ready()
    {
        globals.currentScene = "solace_haven";
        Node2D player = GetNode<Node2D>("playerKaine");
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        if(!questVar.positionChanged){
        if (globals.firstGameLoad == true)
        {
            Vector2 newPositionSolaceHaven = new Vector2(globals.PlayerStartSolaceHavenX, globals.PlayerStartSolaceHavenY);
            player.Position = newPositionSolaceHaven;
        }
        }
        rose = GetNode<Area2D>("Area2D13");
        poem = GetNode<CanvasLayer>("Poem");
        tomb1 = GetNode<FakeTomb>("Area2D");
        tomb2 = GetNode<FakeTomb>("Area2D2");
        tomb3 = GetNode<FakeTomb>("Area2D3");
        tomb4 = GetNode<FakeTomb>("Area2D4");
        tomb5 = GetNode<FakeTomb>("Area2D5");
        tomb6 = GetNode<FakeTomb>("Area2D6");
        tomb7 = GetNode<FakeTomb>("Area2D7");
        tomb8 = GetNode<FakeTomb>("Area2D8");
        tomb9 = GetNode<FakeTomb>("Area2D9");
        tomb10 = GetNode<TrueTomb>("Area2D10");
        tomb11 = GetNode<TrueTomb>("Area2D11");
        tomb12 = GetNode<TrueTomb>("Area2D12");
    }

    public override void _Process(double delta)
    {
        ChangeScene();
    }

    public void enable(){
        tomb1.chosen = false;
        tomb2.chosen = false;
        tomb3.chosen = false;
        tomb4.chosen = false;
        tomb5.chosen = false;
        tomb6.chosen = false;
        tomb7.chosen = false;
        tomb8.chosen = false;
        tomb9.chosen = false;
        tomb10.chosen = false;
        tomb11.chosen = false;
        tomb12.chosen = false;      
    }

    public void _on_solace_haven_exit_point_body_entered(Node2D body)
    {
        if (body is playerKaine)
        {
            globals.transitionScene = true;
            globals.targetScene = "serenavon";
        }
    }

    public void showRose(){
        rose.Show();
    }

    public void showPoem(){
        poem.Show();
        questVar.roseStarted = true;
    }
    private void ChangeScene()
    {
        if (globals.transitionScene == true)
        {
            if (globals.targetScene == "serenavon")
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");
                globals.firstGameLoad = false;
                globals.firstIvoryLoad = false;
                globals.firstSolaceLoad = false;
                globals.FinishChangeScene();
            }
        }
    }
}
