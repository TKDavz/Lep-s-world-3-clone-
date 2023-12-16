using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReqUpdatePosition
{
    public ReqUpdatePosition(string email, string sceneName, float positionX, float positionY, float positionZ)
    {
        this.email = email;
        this.sceneName = sceneName;
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
    }

    // Start is called before the first frame update

    public string email { get; set; }
    public string sceneName { get; set; }
    public float positionX { get; set; }
    public float positionY { get; set; }
    public float positionZ { get; set; }
}
