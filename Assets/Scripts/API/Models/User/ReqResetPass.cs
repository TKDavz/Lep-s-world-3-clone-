using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReqResetPass 
{
    public ReqResetPass(string email, string emailToChangePassword)
    {
        this.email = email;
        this.emailToChangePassword = emailToChangePassword;
    }

    public string email { get; set; }
    public string emailToChangePassword { get; set; }
}
