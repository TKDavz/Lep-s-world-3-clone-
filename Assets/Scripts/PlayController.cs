using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Continue()
    {
        try
        {
            SinglePatterns.Instance.isContinue = true;
            SceneManager.LoadScene(SinglePatterns.Instance.PlayScene);
        } catch (Exception e)
        {
            Debug.LogException(e);
        }

    }

    public void NewGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void  Pause(bool isPause)
    {
        Time.timeScale = isPause ? 0 : 1;
    }

    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
