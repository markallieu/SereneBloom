using Godot;
using System;

public partial class end_credit : Node2D
{
    [Export] AnimationPlayer anim;
    Label credit;
    public override void _Ready()
    {
        credit = GetNode<Label>("Label");
        anim.Play("Morale");
    }
    
    public void _on_animation_player_animation_finished(StringName animName){
        if(animName == "Morale"){
            credit.Show();
            anim.Play("credit");
        }else{
        GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/magic_minigame_credit.tscn");
        }
    }
}
