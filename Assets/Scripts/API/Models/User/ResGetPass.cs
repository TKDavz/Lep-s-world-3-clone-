using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static System.Net.WebRequestMethods;

public class ResGetPass
{
    public ResGetPass(int status, string notification, string password, string email)
    {
        this.status = status;
        this.notification = notification;
        this.password = password;
        this.email = email;
    }

    public int status { get; set; }
    public string notification { get; set; }
    public string password { get; set; }
    public string email { get; set; }

}
