using Godot;
using System;

public partial class move_arrow_up : Area2D
{
    public int speed;
    public int sensor = 0;

    public override void _Ready()
    {
        if (globals.magicMinigame == "Tutorial")
        {
            speed = 100;
        }
        if (globals.magicMinigame == "Boulder")
        {
            speed = 200;
        }
        if (globals.magicMinigame == "Lily")
        {
            speed = 250;
        }
        if (globals.magicMinigame == "Blessing")
        {
            speed = 250;
        }
        if (globals.magicMinigame == "Credit")
        {
            speed = 400;
        }
    }

    public override void _Process(double delta)
    {
        Position = new Vector2(Position.X, (float)(Position.Y - speed * delta));

        if (Position.Y < 5)
        {
            QueueFree();
            magic_minigame_tutorial.DecreaseGauge(10);
            magic_minigame_boulder.DecreaseGauge(5);
            magic_minigame_lily.DecreaseGauge(5);
            magic_minigame_bless.DecreaseGauge(5);
        }
        if (sensor == 1)
        {
            if (globals.sensorAU == 1)
            {
                if (Input.IsActionJustPressed("ui_up"))
                {
                    QueueFree();
                }
            }
        }
    }

    public void _on_area_shape_entered(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
    {
        sensor = 1;
    }
    public void _on_area_shape_exited(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
    {
        sensor = 0;
    }
}
