using Godot;
using System;

public partial class globals : Node
{
    public static bool transitionScene = false;
    public static string currentScene = "";
    public static string targetScene = "";    
    public static bool firstGameLoad = true;
    public static bool firstIvoryLoad = true;
    public static bool firstSolaceLoad = true;
    public static bool firstThomasShopLoad = true;
    public static bool firstRevaHouseLoad = true;

    public static bool textPlayed = false;

    public static void FinishChangeScene()
    {
        if (transitionScene == true)
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
            else if (currentScene == "serenavon")
            {
                currentScene = "ivory_lake";
            }
            else if (currentScene == "ivory_lake")
            {
                currentScene = "serenavon";
            }
            else if (currentScene == "thomas_shop")
            {
                currentScene = "serenavon";
            }
            else if (currentScene == "reva_house")
            {
                currentScene = "serenavon";
            }
        }
    }

    public static float PlayerStartCliffsideX = 271f;
    public static float PlayerStartCliffsideY = 374f;
    public static float PlayerExitCliffisideX = 223f;
    public static float PlayerExitCliffsideY = 8f;

    public static float PlayerStartSerenavonX = 854f;
    public static float PlayerStartSerenavonY = 1348f;

    public static float PlayerExitSerenavon1X = 10f;
    public static float PlayerExitSerenavon1Y = 1122f;
    public static float PlayerExitSerenavon2X = 471f;
    public static float PlayerExitSerenavon2Y = 405f;
    public static float PlayerExitSerenavon3X = 889f;
    public static float PlayerExitSerenavon3Y = 1093f;
    public static float PlayerExitSerenavon4X = 360f;
    public static float PlayerExitSerenavon4Y = 1082f;

    public static float PlayerStartIvoryLakeX = 899f;
    public static float PlayerStartIvoryLakeY = 723f;

    public static float PlayerStartSolaceHavenX = 368f;
    public static float PlayerStartSolaceHavenY = 661f;

    public static float PlayerStartThomasShopX = 250f;
    public static float PlayerStartThomasShopY = 313f;

    public static float PlayerStartRevaHouseX = 250f;
    public static float PlayerStartRevaHouseY = 313f;

    public void _on_dialogic_signal(string arg){
        GD.Print(arg);
    }
}
