using Godot;
using System;

public partial class bandit : CharacterBody2D
{
    [Export] ProgressBar HealthBar;
    [Export] AnimationPlayer AnimationPlayer;
    [Export] Node2D _focus;
    

    [Export] public const float maxHealth = 7f;

    private float _health = 7;

    public float Health
    {
        get { return _health; }
        set
        {
            _health = value;
            UpdateProgressBar();
        }
    }
    public void UpdateProgressBar()
    {
        float percentage = (_health / maxHealth);
        HealthBar.Value = Mathf.Clamp(percentage, 0.0f, 10.0f);
    }

    public void PlayAnimation()
    {
        AnimationPlayer.Play("hurt"); 
    }

    public void Focus()
    {
        _focus.Show(); 
    }

    public void Unfocus()
    {
        _focus.Hide();
    }

    public void TakeDamage(float value)
    {
        Health -= value;
        PlayAnimation();
    }
}



