using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class GetText : MonoBehaviour
{
    public TMP_InputField inputField;
    private string filePathRead = "Assets/PromptBased/userpromptbased.json";

    public void GetInputToFile()
    {
        DataFormat myData = ReadJsonFile();

        NewDataFormat dataFormat = new NewDataFormat();
        dataFormat.gender = myData.gender;
        dataFormat.age = myData.age;
        dataFormat.location = inputField.text;

        string json = JsonUtility.ToJson(dataFormat);
        Debug.Log(json);

        FileStream fileStream = new FileStream(filePathRead, FileMode.OpenOrCreate);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }

    private DataFormat ReadJsonFile() {
        FileStream fileStream = new FileStream(filePathRead, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);
        DataFormat returnedData = JsonUtility.FromJson<DataFormat>(json);

        return returnedData;
    }
}

public class DataFormat
{
    public string gender;
    public string age;
}

public class NewDataFormat
{
    public string gender;
    public string age;
    public string location;
}