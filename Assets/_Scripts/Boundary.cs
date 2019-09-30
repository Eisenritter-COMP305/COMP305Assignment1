using System.Collections;
using System.Collections.Generic;


namespace Util { 
[System.Serializable]
public class Boundary
{
    public float RightBounds;
    public float LeftBounds;
    public float TopBounds;
    public float BottomBounds;

    /// <summary>
    /// This is the constructor for the Boundary class
    /// </summary>
    /// <param name="Top"></param>
    /// <param name="Right"></param>
    /// <param name="Bottom"></param>
    /// <param name="Left"></param>
    public Boundary(float Top = 0.0f, float Right = 0.0f, float Bottom = 0.0f, float Left = 0.0f)
    {
        TopBounds = Top;
        RightBounds = Right;
        BottomBounds = Bottom;
        LeftBounds = Left;
    }
}
}