using Godot;
using System;
using System.Diagnostics.Contracts;

public partial class magic_minigame_boulder : Node2D
{
    private readonly PackedScene AD = (PackedScene)ResourceLoader.Load("res://essential/scenes/magic_minigame/basic/move_arrow_down.tscn");
    private readonly PackedScene AL = (PackedScene)ResourceLoader.Load("res://essential/scenes/magic_minigame/basic/move_arrow_left.tscn");
    private readonly PackedScene AR = (PackedScene)ResourceLoader.Load("res://essential/scenes/magic_minigame/basic/move_arrow_right.tscn");
    private readonly PackedScene AU = (PackedScene)ResourceLoader.Load("res://essential/scenes/magic_minigame/basic/move_arrow_up.tscn");

    [Export] Timer timer;
    [Export] AnimatedSprite2D animation;
    [Export] Marker2D ADMarker;
    [Export] Marker2D ALMarker;
    [Export] Marker2D ARMarker;
    [Export] Marker2D AUMarker;

    public int random = 0;
    public RandomNumberGenerator RNG = new RandomNumberGenerator();

    [Export] ProgressBar magicGauge;
    public static int magic = 0;
    public static int mana = 10;
    public static AnimationPlayer Fail;

    public static magic_minigame_boulder Instance { get; private set; }

    public static AnimationPlayer magicText;
    public static AnimatedSprite2D magicSpell;
    public static CanvasLayer magicComplete;
    public static Label magicChant;

    public static int overLimitCount = 0;
    private const int maxEntries = 3;
    quest_variables questVar;
    
    

    public override void _Ready()
    {
        globals.magicMinigame = "Boulder";
        Instance = this;
        magicGauge.Value = magic;
        animation.Play("Magic");

        magicText = GetNode<AnimationPlayer>("Magic_Complete/AnimationPlayer");
        magicComplete = GetNode<CanvasLayer>("Magic_Complete");
        magicSpell = GetNode<AnimatedSprite2D>("Magic_Complete/AnimatedSprite2D");
        magicChant = GetNode<Label>("Magic_Complete/Label");
        questVar = GetNode<quest_variables>("/root/QuestVariables");
        magicComplete.Hide();
        magic = 149;
    }

    public void _on_timer_timeout()
    {
        timer.Start();
        RNG.Randomize();
        var randomInt = RNG.RandiRange(0, 4);
        random = randomInt;

        if (random == 1)
        {
            Node2D ad = (Node2D)AD.Instantiate();
            GetParent().AddChild(ad);
            ad.Position = ADMarker.GlobalPosition;
        }
        else if (random == 2)
        {
            Node2D al = (Node2D)AL.Instantiate();
            GetParent().AddChild(al);
            al.Position = ALMarker.GlobalPosition;
        }
        else if (random == 3)
        {
            Node2D ar = (Node2D)AR.Instantiate();
            GetParent().AddChild(ar);
            ar.Position = ARMarker.GlobalPosition;
        }
        else if (random == 4)
        {
            Node2D au = (Node2D)AU.Instantiate();
            GetParent().AddChild(au);
            au.Position = AUMarker.GlobalPosition;
        }
    }

    public static void IncreaseGauge(int amount)
    {
        int remainingSpace = 150 - magic;
        if (amount > remainingSpace)
        {
            magic += remainingSpace;
        }
        else
        {
            magic += amount;
        }

        if (Instance != null)
        {
            Instance.magicGauge.Value = magic;
            if (magic == 150)
            {
                Instance.StopGame();
            }
            if (magic <= amount)
            {
                overLimitCount = 0;
            }
        }
    }

    public static void DecreaseGauge(int amount)
    {
        if (magic > 0)
        {
            if (amount > magic)
            {
                magic = 0;
            }
            else
            {
                magic -= amount;            
            }

            if (Instance != null)
            {
                Instance.magicGauge.Value = magic;
            }
        }
    }
    public void _on_overlimit_area_shape_entered(Rid area_rid, Area2D area, int area_shape_index, int local_shape_index)
    {
        if (magic == 0)
        {
            overLimitCount++;
            if (overLimitCount >= maxEntries)
            {
                GetTree().ChangeSceneToFile("res://essential/scenes/magic_minigame/game/game_over.tscn");
            }
        }
    }

    private async void StopGame()
    {
        magicSpell.Hide();
        magicComplete.Show();
        magicChant.Hide();
        await ToSignal(GetTree().CreateTimer(1), "timeout");
        magicText.Play("Text");
        magicChant.Show();
        await ToSignal(GetTree().CreateTimer(9), "timeout");
        magicChant.Hide();
        magicSpell.Show();
        magicSpell.Play("Spell");
        await ToSignal(GetTree().CreateTimer(1), "timeout");
        questVar.boulderDestroyed  = true;
        questVar.needToChangePosition = true;
        questVar.positionChanged = true;
        GetTree().ChangeSceneToFile("res://essential/scenes/worlds/ivory_lake.tscn");
    }
}
