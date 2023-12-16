using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ResUpdatePosition
{
    public ResUpdatePosition(int status, string notification)
    {
        this.status = status;
        this.notification = notification;
    }

    public int status { get; set; }
    public string notification{ get; set; }
}
