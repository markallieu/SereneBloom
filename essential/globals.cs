using Godot;
using System;

public partial class globals : Node
{
    public static bool transitionScene = false;
    public static string currentScene = "";

    public static void FinishChangeScene()
    {
        if (transitionScene == true )
        {
            transitionScene = false;
            if (currentScene == "cliffside")
            {
                currentScene = "serenavon";
            }
            else if (currentScene == "serenavon")
            {
                currentScene = "cliffside"; 
            }
        }
    }

    float PLayerStartPosX = 0f;
    float PLayerEndPosY = 0f;

    float PlayerExitCliffisdePosX = 0f;
    float PlayerExitCliffsidePosY = 0f;
}
