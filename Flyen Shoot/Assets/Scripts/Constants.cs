using UnityEngine;
using System.Collections;

public class Constants
{
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
        Collectable = 10
    }
}