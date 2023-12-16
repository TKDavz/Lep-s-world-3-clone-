using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CallApi : MonoBehaviour
{ 
    private const string API_URL = "https://api.example.com/";


    private IEnumerator GetRequest()
    {
        // Tạo yêu cầu GET đến API
        UnityWebRequest request = UnityWebRequest.Get(API_URL);

        // Gửi yêu cầu và đợi phản hồi
        yield return request.SendWebRequest();

        // Kiểm tra lỗi
        if (request.result == UnityWebRequest.Result.Success)
        {
            // Phản hồi thành công, xử lý dữ liệu
            Debug.Log("API Response: " + request.downloadHandler.text);
        }
        else
        {
            // Xử lý lỗi
            Debug.LogError("API Error: " + request.error);
        }
    }

    IEnumerator PostRequest(string postData)
    {
        UnityWebRequest request = UnityWebRequest.Post(API_URL, postData);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("POST Request Successful");
        }
        else
        {
            Debug.LogError("POST Request Error: " + request.error);
        }
    }

    IEnumerator PutRequest(string putData)
    {
        UnityWebRequest request = UnityWebRequest.Put(API_URL, putData);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("PUT Request Successful");
        }
        else
        {
            Debug.LogError("PUT Request Error: " + request.error);
        }
    }

    IEnumerator DeleteRequest()
    {
        UnityWebRequest request = UnityWebRequest.Delete(API_URL);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("DELETE Request Successful");
        }
        else
        {
            Debug.LogError("DELETE Request Error: " + request.error);
        }
    }

    IEnumerator Login(string loginData)
    {
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:1239/user/login", loginData);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("POST Login Request Successful");
        }
        else
        {
            Debug.LogError("POST Login Request Error: " + request.error);
        }
    }


}
