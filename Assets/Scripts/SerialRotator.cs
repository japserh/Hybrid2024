using UnityEngine;
using System.Linq;

public class SerialRotator : SerialReader
{
    private string rotation_prefix = "pos:";
    private string direction_prefix = "dir:";
    
    private int rotation;
    private int direction;
    
    public override void HandleMessage(string message)
    {
        int pos = 0;
        int dir = 0;
        string[] words = message.Split(" ");
        
        if (words[0] == rotation_prefix)
        {
            int.TryParse(words[1], out pos);
        }
        if (words[2] == direction_prefix)
        {
            int.TryParse(words[1], out dir);
        }
        
        // 20 step Rotary Encoder
        rotation = pos * 18;
        direction = dir;

        SetRotation(rotation);
    }

    private void SetRotation(int rotation)
    {
        gameObject.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }
}
