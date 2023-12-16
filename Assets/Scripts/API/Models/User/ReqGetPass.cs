using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReqGetPass
{
    public ReqGetPass(string email)
    {
        this.email = email;
    }

    public string email { get; set; }
}
