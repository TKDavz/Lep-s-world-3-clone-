using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static System.Net.WebRequestMethods;

public class ResResetPass
{
    public ResResetPass(int status, string notification, string otp, string email, string type)
    {
        this.status = status;
        this.notification = notification;
        this.otp = otp;
        this.email = email;
        this.type = type;
    }

    public int status { get; set; }
    public string notification { get; set; }
    public string otp { get; set; }
    public string email { get; set; }
    public string type { get; set; }
}
