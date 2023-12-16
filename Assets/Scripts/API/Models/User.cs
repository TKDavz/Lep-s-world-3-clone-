using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class User
{
    public User(string email, string password, Vector3 position, string sceneName, int numberOfCoins, int numberOfTannenzapfen)
    {
        this.email = email;
        this.password = password;
        this.position = position;
        this.sceneName = sceneName;
        this.numberOfCoins = numberOfCoins;
        this.numberOfTannenzapfen = numberOfTannenzapfen;
    }

    public string email { get; set; }
    public string password { get; set; }
    public Vector3 position { get; set; }
    public string sceneName { get; set; }
    public int numberOfCoins { get; set; }
    public int numberOfTannenzapfen { get; set; }
}
