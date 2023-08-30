using Godot;

public partial class playerKaine : CharacterBody2D
{
    private Vector2 _velocity = Vector2.Zero;
    private Vector2 _moveDirection = Vector2.Zero;
    private string _currentDirection;
    [Export] private const float _speed = 80f;

    public override void _PhysicsProcess(double delta)
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        _moveDirection = Vector2.Zero; // Reset movement direction each frame

        // Move the character body based on the input direction and assigned a string variable direction 
        if (Input.IsActionPressed("ui_right"))
        {
            _currentDirection = "Right";
            _moveDirection.X += 1;
        }
        else if (Input.IsActionPressed("ui_left"))
        {
            _currentDirection = "Left";
            _moveDirection.X -= 1;
        }
        else if (Input.IsActionPressed("ui_down"))
        {
            _currentDirection = "Down";
            _moveDirection.Y += 1;
        }
        else if (Input.IsActionPressed("ui_up"))
        {
            _currentDirection = "Up";
            _moveDirection.Y -= 1;
        }

        // Calculates the _moveDirection vector and then checks if it's >0
        // If true, assign to 1, plays walking animation
        // If false, assign to 0, plays idle
        PlayAnimation(_moveDirection.LengthSquared() > 0 ? 1 : 0);

        // Normalize ensures that the _moveDirection is consistent with the _speed which is 100f
        _velocity = _moveDirection.Normalized() * _speed;

        // Can't use MoveAndSlide(_vector), so _velocity need to be assigned to Velocity, 
        // because MoveAndSlide() can only take Velocity property
        Velocity = _velocity;
        MoveAndSlide();
    }

    public void PlayAnimation(int movement)
    {
        var direction = _currentDirection;
        var animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (direction == "Right")
        {
            animation.FlipH = false;
            if (movement == 1) 
            {
                animation.Play("sideWalk");
            }
            else if (movement == 0)
            {
                animation.Play("sideIdle");
            }
        }

        if (direction == "Left")
        {
            animation.FlipH = true;
            if (movement == 1)
            {
                animation.Play("sideWalk");
            }
            else if (movement == 0)
            {
                animation.Play("sideIdle");
            }
        }

        if (direction == "Down")
        {
            animation.FlipH = false;
            if (movement == 1)
            {
                animation.Play("frontWalk");
            }
            else if (movement == 0)
            {
                animation.Play("frontIdle");
            }
        }

        if (direction == "Up")
        {
            animation.FlipH = false;
            if (movement == 1)
            {
                animation.Play("backWalk");
            }
            else if (movement == 0)
            {
                animation.Play("backIdle");
            }
        }
    }
}
