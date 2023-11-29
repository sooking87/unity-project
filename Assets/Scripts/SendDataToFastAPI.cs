using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Text;

public class SendDataToFastAPI : MonoBehaviour
{
    string filePath = "Assets/PromptBased/userpromptbased.json";
    // string url = "http://127.0.0.1:8000/receive_data";
    public void SendData()
    {
        string json = GetJsonContent();
        string serverUrl = "http://127.0.0.1:8000/data?json_data=" + UnityWebRequest.EscapeURL(json); 
        UploadFile(serverUrl);
    }
    private string GetJsonContent()
    {
        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);
        Debug.Log(json);

        return json;
    }
    private void UploadFile(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            // byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            // request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            // request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            // request.SetRequestHeader("Content-Type", "application/json");
            request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("error: " + request.error);
            }
            if(request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("¼º°ø!!!!!!!!!!!");
                Debug.Log(request.result);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
}
