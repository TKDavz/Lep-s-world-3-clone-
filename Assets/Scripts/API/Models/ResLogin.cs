using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResLogin
{
    public ResLogin(int status, string notification, string username, string scene, int score, float positionX, float positionY, float positionZ)
    {
        this.status = status;
        this.notification = notification;
        this.username = username;
        this.scene = scene;
        this.score = score;
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
    }

    public int status { get; set; }
    public string notification { get; set; }
    public string username { get; set; }
    public string scene { get; set; }
    public int score { get; set; }
    public float positionX { get; set; }
    public float positionY { get; set; }
    public float positionZ { get; set; }


}
