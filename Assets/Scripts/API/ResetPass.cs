using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ResetPass : MonoBehaviour
{
    public Text toatError;

    public InputField edtEmail;
    public InputField edtPassword;
    public InputField edtEmailToChangePassword;
    public InputField edtOtp;

    public string otp;

    private void Start()
    {
        edtEmailToChangePassword.text = "";
        edtEmail.text = "duytk41@gmail.com";
    }
    private void Update()
    {

    }

    public void SendOtp()
    {
        try
        {
            string email = edtEmail.text;
            string emailToChangePassword = edtEmailToChangePassword.text;

            ReqResetPass reqResetPass = new ReqResetPass(email, emailToChangePassword);

            StartCoroutine(OnSendOtp(reqResetPass));
        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e);
        }


    }

    IEnumerator OnSendOtp(ReqResetPass reqResetPass)
    {
        //…
        string jsonStringRequest = JsonConvert.SerializeObject(reqResetPass);

        var request = new UnityWebRequest("http://localhost:1239/otp/send-otp", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            var jsonString = request.downloadHandler.text.ToString();
            ResResetPass resResetPass = JsonConvert.DeserializeObject<ResResetPass>(jsonString);

            if (resResetPass != null)
            {
                if (toatError != null)
                {
                    toatError.text = resResetPass.notification;
                    toatError.gameObject.SetActive(true);

                }
                Debug.Log(resResetPass.notification);
            }
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            ResResetPass resResetPass = JsonConvert.DeserializeObject<ResResetPass>(jsonString);


            if (resResetPass != null)
            {

                if (resResetPass.status == 200)
                {

                    try
                    {
                        otp = resResetPass.otp;
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error: " + e);
                    }
                }
                if (toatError != null)
                {
                    toatError.text = resResetPass.notification;
                    toatError.gameObject.SetActive(true);
                }
                Debug.Log(resResetPass.notification);

            }
        }

        request.Dispose();
    }



    public void GetPass()
    {
        try
        {
            if (edtOtp.text.Equals(otp))
            {
                string emailToChangePassword = edtEmailToChangePassword.text;

                ReqGetPass reqGetPass = new ReqGetPass(emailToChangePassword);

                StartCoroutine(OnGetPass(reqGetPass));
            } else
            {
                toatError.text = "Otp không đúng";
                toatError.gameObject.SetActive(true);
            }

        }
        catch (Exception e)
        {
            Debug.Log("Error: " + e);
        }


    }

    IEnumerator OnGetPass(ReqGetPass reqGetPass)
    {
        //…
        string jsonStringRequest = JsonConvert.SerializeObject(reqGetPass);

        var request = new UnityWebRequest("http://localhost:1239/user/password", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            var jsonString = request.downloadHandler.text.ToString();
            ResGetPass resGetPass = JsonConvert.DeserializeObject<ResGetPass>(jsonString);

            if (resGetPass != null)
            {
                if (toatError != null)
                {
                    toatError.text = resGetPass.notification;
                    toatError.gameObject.SetActive(true);

                }
                Debug.Log(resGetPass.notification);
            }
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            ResGetPass resGetPass = JsonConvert.DeserializeObject<ResGetPass>(jsonString);


            if (resGetPass != null)
            {

                if (resGetPass.status == 200)
                {

                    try
                    {
                        edtPassword.text = "Pass: " + resGetPass.password;
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Error: " + e);
                    }
                }
                if (toatError != null)
                {
                    toatError.text = resGetPass.notification;
                    toatError.gameObject.SetActive(true);
                }
                Debug.Log(resGetPass.notification);

            }
        }

        request.Dispose();
    }
}
