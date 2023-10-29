using Godot;
using System;

public partial class idle_arrow_up : Area2D
{
    [Export] AnimationPlayer animation;
    private int sensor = 0;
    Node2D parent;
    public override void _Ready()
    {
        parent = GetParent<Node2D>();
    }

    public override void _Process(double delta)
    {
        if (sensor == 1)
        {
            if (Input.IsActionJustPressed("ui_up"))
            {
                animation.Play("Good");
                switch (parent.Name){
                    case "Magic_Minigame_Lily":
                        magic_minigame_lily.IncreaseGauge(5);
                        break;
                    case "Magic_Minigame_Boulder":
                        magic_minigame_boulder.IncreaseGauge(5);
                        break;
                    case "Magic_Minigame_Bless":
                        magic_minigame_bless.IncreaseGauge(5);
                        break;
                    case "Magic_Minigame_Credit":
                        magic_minigame_credit.IncreaseGauge(20);
                        break;
                    case "Magic_Minigame_Tutorial":
                        magic_minigame_tutorial.IncreaseGauge(10);
                        break;
                } 
            }
        }
        if (sensor == 0)
        {
            if (Input.IsActionJustPressed("ui_up"))
            {
                animation.Play("Bad");
                switch (parent.Name){
                    case "Magic_Minigame_Lily":
                         magic_minigame_lily.DecreaseGauge(5);
                        break;
                    case "Magic_Minigame_Boulder":
                        magic_minigame_boulder.DecreaseGauge(5);
                        break;
                    case "Magic_Minigame_Bless":
                        magic_minigame_bless.DecreaseGauge(5);
                        break;
                    case "Magic_Minigame_Tutorial":
                        magic_minigame_tutorial.DecreaseGauge(10);
                        break;
                } 
            }
        }
    }

    public void _on_area_shape_entered(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
    {
        sensor = 1;
        globals.sensorAU = 1;
    }

    public void _on_area_shape_exited(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
    {
        sensor = 0;
        globals.sensorAU = 0;

    }
}
