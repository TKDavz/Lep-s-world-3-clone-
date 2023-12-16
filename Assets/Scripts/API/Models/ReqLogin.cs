using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReqLogin 
{
    public ReqLogin(string username, string password)
    {
        this.email = username;
        this.password = password;
    }

    public string email { get; set; }
    public string password { get; set; }


}
