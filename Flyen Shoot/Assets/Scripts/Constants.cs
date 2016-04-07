using UnityEngine;
using System.Collections;

public class Constants
{
    public static int PIXELS_TO_UNIT = 100;

    public class Levels
    {
        public static string MENU = "0_Menu";
    }

    public class Tags
    {
        public static string PLAYER = "Player";
        public static string LEVEL_EVENTS = "Level Events";
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight
    }

    public enum Layers
    {
        Player = 8,
        Enemy = 9,
        Collectable = 10,
        PlayerBullet = 11,
        IgnoreCollision = 12
    }
}