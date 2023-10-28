using Godot;
using System;

public partial class idle_arrow_right : Area2D
{
    [Export] AnimationPlayer animation;
    private int sensor = 0;

    public override void _Process(double delta)
    {
        if (sensor == 1)
        {
            if (Input.IsActionJustPressed("ui_right"))
            {
                animation.Play("Good");
                magic_minigame_tutorial.IncreaseGauge(10);
                magic_minigame_boulder.IncreaseGauge(5);
                magic_minigame_lily.IncreaseGauge(5);
            }
        }
        if (sensor == 0)
        {
            if (Input.IsActionJustPressed("ui_right"))
            {
                animation.Play("Bad");
                magic_minigame_tutorial.DecreaseGauge(10);
                magic_minigame_boulder.DecreaseGauge(5);
                magic_minigame_lily.DecreaseGauge(5);
            }
        }
    }

    public void _on_area_shape_entered(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
    {
        sensor = 1;
        globals.sensorAR = 1;
    }

    public void _on_area_shape_exited(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
    {
        sensor = 0;
        globals.sensorAR = 0;
    }
}
