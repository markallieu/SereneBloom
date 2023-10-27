using Godot;
using System;
using System.Security.Cryptography;
using Godot.Collections;

public partial class move_arrow_left : Area2D
{
    public int speed = 50*4;
    public int sensor = 0;

    public override void _Process(double delta)
    {
        Position = new Vector2(Position.X, (float)(Position.Y - speed * delta));

        if (Position.Y < 5)
        {
            QueueFree();
            magic_minigame_tutorial.DecreaseGauge(10);
        }
        if (sensor == 1)
        {
            if (globals.sensorAL == 1)
            {
                if (Input.IsActionJustPressed("ui_left"))
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
