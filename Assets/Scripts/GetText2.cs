using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using static UnityEngine.LightProbeProxyVolume;

public class GetText2 : MonoBehaviour
{
    public TMP_InputField inputField;
    private string filePathRead = "Assets/PromptBased/userpromptbased.json";

    public void GetInputToFile2()
    {
        NewDataFormat newData = ReadJsonFile();

        NewDataFormat2 dataFormat2 = new NewDataFormat2();
        dataFormat2.gender = newData.gender;
        dataFormat2.age = newData.age;
        dataFormat2.location = newData.location;
        dataFormat2.situation = inputField.text;

        string json = JsonUtility.ToJson(dataFormat2);
        Debug.Log(json);

        FileStream fileStream = new FileStream(filePathRead, FileMode.OpenOrCreate);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    private NewDataFormat ReadJsonFile()
    {
        FileStream fileStream = new FileStream(filePathRead, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);
        NewDataFormat returnedData = JsonUtility.FromJson<NewDataFormat>(json);

        return returnedData;
    }
}

public class NewDataFormat2
{
    public string gender;
    public string age;
    public string location;
    public string situation;
}
