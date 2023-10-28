using Godot;
using System;

public partial class game_over : Node2D
{
    [Export] AnimationPlayer anim;
    [Export] Button Retry;
    [Export] Button Quit;

    public override void _Ready()
    {
        GameOver();
    }

    private async void GameOver()
    {
        Retry.Hide();
        Quit.Hide();
        anim.Play("Text");
        await ToSignal(GetTree().CreateTimer(2), "timeout");
        Retry.Show();
        Quit.Show();
    }
    private void _on_retry_pressed()
    {       
        if (globals.magicMinigame == "Tutorial")
        {
            GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/magic_minigame_tutorial.tscn");
            magic_minigame_tutorial.overLimitCount = 0;
        }
        if (globals.magicMinigame == "Boulder")
        {
            GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/magic_minigame_boulder.tscn");
            magic_minigame_boulder.overLimitCount = 0;
        }
        if (globals.magicMinigame == "Lily")
        {
            GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/magic_minigame_lily.tscn");
            magic_minigame_lily.overLimitCount = 0;
        }

    }
    private void _on_quit_pressed()
    {
        if (globals.magicMinigame == "Tutorial")
        {
            GetTree().ChangeSceneToFile("res://essential/scenes/worlds/serenavon.tscn");
        }
        if (globals.magicMinigame == "Boulder")
        {
            GetTree().ChangeSceneToFile("res://essential/scenes/worlds/ivory_lake.tscn");
        }
        if(globals.magicMinigame == "Lily")
        {
            GetTree().ChangeSceneToFile("res://essential/scenes/worlds/ivory_lake.tscn");
        }
    }
}
