using Godot;
using System;

public partial class end_credit : Node2D
{
    [Export] AnimationPlayer anim;
    public override void _Ready()
    {
        Credit();
    }
    private async void Credit()
    {
        anim.Play("Credit");
        await ToSignal(GetTree().CreateTimer(25), "timeout");
        GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/magic_minigame_credit.tscn");
    }
}
