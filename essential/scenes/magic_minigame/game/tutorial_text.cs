using Godot;
using System;

public partial class tutorial_text : Node2D
{
    [Export] public TextureRect image;
    [Export] public Label text1;
    [Export] public Label text2;
    [Export] public Label text3;
    [Export] public Label text4;
    [Export] public Label text5;
    [Export] public Label text6;
    [Export] public Label text7;
    [Export] public Label text8;
    [Export] public ColorRect box;
    [Export] public AnimationPlayer animation;

    public override void _Ready()
    {
        Tutorial();
    }
    public async void Tutorial()
    {
        image.Hide();
        text1.Hide();
        text2.Hide();
        text3.Hide();
        text4.Hide();
        text5.Hide();
        text6.Hide();
        text7.Hide();
        text8.Hide();
        box.Hide();

        await ToSignal(GetTree().CreateTimer(2), "timeout");
        box.Show();

        animation.Play("Anim");
        text1.Show();
        await ToSignal(GetTree().CreateTimer(8), "timeout");
        text1.Hide();

        animation.Play("Anim_2");
        text2.Show();
        await ToSignal(GetTree().CreateTimer(8), "timeout");
        text2.Hide();
   
        image.Show();
        animation.Play("Fade");
        animation.Play("Anim_3");
        text3.Show();
        await ToSignal(GetTree().CreateTimer(8), "timeout");
        text3.Hide();

        animation.Play("Anim_4");
        text4.Show();
        await ToSignal(GetTree().CreateTimer(8), "timeout");
        text4.Hide();

        animation.Play("Anim_5");
        text5.Show();
        await ToSignal(GetTree().CreateTimer(10), "timeout");
        text5.Hide();

        animation.Play("Anim_6");
        text6.Show();
        await ToSignal(GetTree().CreateTimer(8), "timeout");
        text6.Hide();

        animation.Play("Anim_7");
        text7.Show();
        await ToSignal(GetTree().CreateTimer(8), "timeout");
        text7.Hide();

        animation.Play("Anim_8");
        text8.Show();
        await ToSignal(GetTree().CreateTimer(12), "timeout");

        GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/magic_minigame_tutorial.tscn");
        
    }
}
