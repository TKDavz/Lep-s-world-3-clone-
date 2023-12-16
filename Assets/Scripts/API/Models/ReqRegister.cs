using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReqRegister
{
    public ReqRegister(string email, string password, string repassword)
    {
        this.email = email;
        this.password = password;
        this.repassword = repassword;
    }

    public string email { get; set; }
    public string password { get; set; }
    public string repassword { get; set; }


}
