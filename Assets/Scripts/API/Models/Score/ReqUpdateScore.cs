using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReqUpdateScore
{
    public ReqUpdateScore(string email, int numberOfCoins)
    {
        this.email = email;
        this.numberOfCoins = numberOfCoins;

    }

    public ReqUpdateScore(string email, int numberOfCoins, int numberOfTannenzapfen)
    {
        this.email = email;
        this.numberOfCoins = numberOfCoins;
        this.numberOfTannenzapfen = numberOfTannenzapfen;
    }

    public string email { get; set; }
    public int numberOfCoins { get; set; }
    public int numberOfTannenzapfen { get; set; }
}
