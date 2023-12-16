using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePatterns : MonoBehaviour
{
    public static SinglePatterns Instance { get; private set; }

    public bool isContinue = false;
    public int Score = 0;
    public Vector3 Position;
    public string PlayScene = "Scene1";
    public string Username = "";


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
