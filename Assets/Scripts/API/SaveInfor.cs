using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveInfor : MonoBehaviour
{
    public Text toatPo;
    public Text toatScore;

    public Player player;

    private void Start()
    {

    }
    private void Update()
    {

    }

    public void savePositon(string scene)
    {
        try
        {
            string email = SinglePatterns.Instance.Username;
            string sceneName = scene != "" && scene != null ? scene : SinglePatterns.Instance.PlayScene;

            float positionX = player.transform.position.x;
            float positionY = player.transform.position.y;
            float positionZ = player.transform.position.z;


            ReqUpdatePosition reqUpdatePosition = new ReqUpdatePosition(email, sceneName, positionX, positionY, positionZ);

            StartCoroutine(OnSavePositon(reqUpdatePosition));
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e);
        }


    }

    IEnumerator OnSavePositon(ReqUpdatePosition reqUpdatePosition)
    {
        //…
        string jsonStringRequest = JsonConvert.SerializeObject(reqUpdatePosition);

        var request = new UnityWebRequest("http://127.0.1.1:1239/user/position", "PUT");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            var jsonString = request.downloadHandler.text.ToString();
            ResUpdatePosition resUpdatePosition = JsonConvert.DeserializeObject<ResUpdatePosition>(jsonString);

            if (resUpdatePosition != null)
            {
                if (toatPo != null)
                {
                    toatPo.text = resUpdatePosition.notification;
                    toatPo.gameObject.SetActive(true);

                }
                Debug.Log(resUpdatePosition.notification);
            }
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            ResUpdatePosition resUpdatePosition = JsonConvert.DeserializeObject<ResUpdatePosition>(jsonString);


            if (resUpdatePosition != null)
            {

                if (resUpdatePosition.status == 200)
                {

                    try
                    {

                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error: " + e);
                    }
                }
                if (toatPo != null)
                {
                    toatPo.text = resUpdatePosition.notification;
                    toatPo.gameObject.SetActive(true);
                }
                Debug.Log(resUpdatePosition.notification);

            }
        }

        request.Dispose();
    }

    public void saveScore(int score)
    {
        try
        {
            string email = SinglePatterns.Instance.Username;


            ReqUpdateScore reqUpdateScore = new ReqUpdateScore(email, score);

            StartCoroutine(OnSaveScore(reqUpdateScore));
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e);
        }

    }

    IEnumerator OnSaveScore(ReqUpdateScore reqUpdateScore)
    {
        //…
        string jsonStringRequest = JsonConvert.SerializeObject(reqUpdateScore);

        var request = new UnityWebRequest("http://127.0.1.1:1239/user/coins-and-tannenzapfens", "PUT");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            var jsonString = request.downloadHandler.text.ToString();
            ResUpdateScore resUpdateScore = JsonConvert.DeserializeObject<ResUpdateScore>(jsonString);

            if (resUpdateScore != null)
            {
                if (toatScore != null)
                {
                    toatScore.text = resUpdateScore.notification;
                    toatScore.gameObject.SetActive(true);

                }
                Debug.Log(resUpdateScore.notification);
            }
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            ResUpdateScore resUpdateScore = JsonConvert.DeserializeObject<ResUpdateScore>(jsonString);


            if (resUpdateScore != null)
            {

                if (resUpdateScore.status == 200)
                {

                    try
                    {

                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error: " + e);
                    }
                }
                if (toatScore != null)
                {
                    toatScore.text = resUpdateScore.notification;
                    toatScore.gameObject.SetActive(true);
                }
                Debug.Log(resUpdateScore.notification);

            }
        }

        request.Dispose();
    }
}

