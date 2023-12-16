using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckLogin : MonoBehaviour
{

    public InputField edtEmail;
    public InputField edtPassword;

    public Text textError;


    // Start is called before the first frame update
    void Start()
    {
        edtEmail.text = "email@gmail.com";
        edtPassword.text = "12345";

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void check()
    {


        var user = edtEmail.text;
        var password = edtPassword.text;


        ReqLogin reqLogin = new ReqLogin(user, password);

        StartCoroutine(CheckLog(reqLogin));

        //if (user == null || password == null)
        //{
        //    if (textError != null)
        //    {
        //        textError.text = "Error text";
        //        textError.gameObject.SetActive(true);
        //    }
        //    return;
        //}
        //else if (user == "abc" && password == "abc")
        //{
        //    if (textError != null)
        //    {
        //        textError.text = "Error text";
        //        textError.gameObject.SetActive(false);
        //    }

        //    SceneManager.LoadScene("Scene1");
        //}
        //else
        //{
        //    if (textError != null)
        //    {
        //        textError.text = "Not found";
        //        textError.gameObject.SetActive(true);
        //    }
        //}
    }

    IEnumerator CheckLog(ReqLogin reqLogin)
    {
        //…
        string jsonStringRequest = JsonConvert.SerializeObject(reqLogin);


        var request = new UnityWebRequest("http://127.0.1.1:1239/user/login", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            var jsonString = request.downloadHandler.text.ToString();
            ResLogin resLogin = JsonConvert.DeserializeObject<ResLogin>(jsonString);

            if (resLogin != null)
            {
                Debug.Log(resLogin.notification);
            }
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            ResLogin resLogin = JsonConvert.DeserializeObject<ResLogin>(jsonString);


            if (resLogin != null)
            {
                if (resLogin.status == 200)
                {
                    Debug.Log(resLogin.scene);
                    SceneManager.LoadScene("Main");
                    try
                    {
                        SinglePatterns.Instance.Username = resLogin.username;
                        SinglePatterns.Instance.Score = resLogin.score;
                        SinglePatterns.Instance.PlayScene = resLogin.scene;
                        if (resLogin.positionX == -1 && resLogin.positionY == -1 &&  resLogin.positionZ == -1)
                        {

                        } else
                        {
                            SinglePatterns.Instance.Position = new Vector3(resLogin.positionX, resLogin.positionY, resLogin.positionZ);
                        }

                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error: " + e);
                    }
                }


                if (textError != null)
                {

                    textError.text = resLogin.notification;
                    textError.gameObject.SetActive(true);
                    Debug.Log(resLogin.notification);

                }

            }
        }

        request.Dispose();
    }
}
