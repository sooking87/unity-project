using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class GetText3 : MonoBehaviour
{
    public TMP_InputField inputField;
    private string filePathRead = "Assets/PromptBased/userpromptbased.json";

    public void GetInputToFile3()
    {
        NewDataFormat2 newData = ReadJsonFile();

        FinalDataFormat dataFormat2 = new FinalDataFormat();
        dataFormat2.gender = newData.gender;
        dataFormat2.age = newData.age;
        dataFormat2.location = newData.location;
        dataFormat2.situation = newData.situation;
        dataFormat2.feeling = inputField.text;

        string json = JsonUtility.ToJson(dataFormat2);
        Debug.Log(json);

        FileStream fileStream = new FileStream(filePathRead, FileMode.OpenOrCreate);
        byte[] data = Encoding.UTF8.GetBytes(json);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
    private NewDataFormat2 ReadJsonFile()
    {
        FileStream fileStream = new FileStream(filePathRead, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);
        NewDataFormat2 returnedData = JsonUtility.FromJson<NewDataFormat2>(json);

        Debug.Log(returnedData.gender);
        Debug.Log(returnedData.age);
        Debug.Log(returnedData.location);
        Debug.Log(returnedData.situation);

        return returnedData;
    }
}

[System.Serializable]
public class FinalDataFormat
{
    public string gender;
    public string age;
    public string location;
    public string situation;
    public string feeling;
}
