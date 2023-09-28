using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

public partial class BanditGroup : Node2D
{
    private List<bandit> enemies;
    private Godot.Collections.Array actionQueue = new Godot.Collections.Array();
    private bool isBattling = false;
    private int index = 0;

    [Signal] public delegate void NextPlayerEventHandler();
    private Control choice;
    private Control pacify;
 
    public void EmitNextPlayerSignal()
    {
        EmitSignal(nameof(NextPlayer));
    }

    public override void _Ready()
    {
        enemies = GetChildren().OfType<bandit>().ToList();
        choice = GetNode<Control>("CanvasLayer/Choice");
        pacify = GetNode<Control>("CanvasLayer/Choice/Pacify");
        foreach (Node child in enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Node2D enemy = (Node2D)enemies[i];
                enemy.Position = new Vector2(0, i * 40);
            }
        }
        ShowChoice();
    }

    public override void _Process(double delta)
    {
            if (Input.IsActionJustPressed("ui_up"))
            {
                if (index > 0)
                {
                    index -= 1;
                    SwitchFocus(index, index + 1);
                }
            }

            if (Input.IsActionJustPressed("ui_down"))
            {
                if (index < enemies.Count - 1)
                {
                    index += 1;
                    SwitchFocus(index, index - 1);
                }
            }

            if (Input.IsActionJustPressed("ui_accept"))
            {
                actionQueue.Add(index);
                EmitNextPlayerSignal();
            }

        if (actionQueue.Count == enemies.Count && !isBattling)
        {
            isBattling = true;
            Action(actionQueue);
            ResetFocus();
        }
    }

    private async void Action(Godot.Collections.Array stack)
    {
        foreach (int i in stack)
        {
            if (enemies[i] is bandit banditEnemy)
            {
                banditEnemy.TakeDamage(1);
            }
            await ToSignal(GetTree().CreateTimer(1), "timeout");
        }

        actionQueue.Clear();
        isBattling = false;
        ShowChoice();
    }

    private void SwitchFocus(int x, int y)
    {
        enemies[x].Focus();
        enemies[y].Unfocus();
    }
    private void ShowChoice()
    {
        if (pacify is Control control)
        {
            control.GrabFocus();
        }
    }

    private void ResetFocus()
    {
        index = 0;
        foreach (bandit enemy in enemies)
        {
            enemy.Unfocus();
        }
    }
    private void StartChoosing()
    {
        ResetFocus();
        enemies[0].Focus();
    }
    private void _on_pacify_pressed()
    {
        StartChoosing();
        GD.Print("Pacify button pressed.");
    }

}
