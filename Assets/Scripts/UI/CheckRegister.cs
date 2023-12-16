using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CheckRegister : MonoBehaviour
{
    public InputField edtEmail;
    public InputField edtPassword;
    public InputField edtRePassword;

    public Text textError;


    // Start is called before the first frame update
    void Start()
    {

        edtEmail.text = "email@gmail.com";
        edtPassword.text = "12345";
        edtRePassword.text = "123456";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void check()
    {


        var user = edtEmail.text;
        var password = edtPassword.text;
        var repassword = edtRePassword.text;

        if (password != repassword)
        {

            if (textError != null)
            {
                textError.text = "Password và Repassword phải giống nhau";
                textError.gameObject.SetActive(true);

            }
        }
        else
        {
            ReqRegister reqRegister = new ReqRegister(user, password, repassword);
            textError.gameObject.SetActive(false);

            StartCoroutine(CheckReg(reqRegister));
        }
    }

    IEnumerator CheckReg(ReqRegister reqRegister)
    {
        //…
        string jsonStringRequest = JsonConvert.SerializeObject(reqRegister);

        var request = new UnityWebRequest("http://127.0.1.1:1239/user/register", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            var jsonString = request.downloadHandler.text.ToString();
            ResRegister resRegister = JsonConvert.DeserializeObject<ResRegister>(jsonString);

            if (resRegister != null)
            {

                if (textError != null)
                {

                    textError.text = resRegister.notification;
                    textError.gameObject.SetActive(true);
                    Debug.Log(resRegister.notification);

                }
                Debug.Log(resRegister.notification);
            }
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            ResRegister resRegister = JsonConvert.DeserializeObject<ResRegister>(jsonString);


            if (resRegister != null)
            {

                if( resRegister.status == 200)
                {
                   
                    try {
                        SinglePatterns.Instance.Username = reqRegister.email;
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error: " + e);
                    }
                }

                if (textError != null)
                {

                    textError.text = resRegister.notification;
                    textError.gameObject.SetActive(true);
                    Debug.Log(resRegister.notification);

                }

            }
        }

        request.Dispose();
    }
}
