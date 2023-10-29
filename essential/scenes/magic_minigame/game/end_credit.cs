using Godot;
using System;

public partial class end_credit : Node2D
{
    [Export] AnimationPlayer anim;
    public override void _Ready()
    {
        anim.Play("credit");
    }
    
    public void _on_animation_player_animation_finished(StringName animName){
        GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/magic_minigame_credit.tscn");
    }
}
