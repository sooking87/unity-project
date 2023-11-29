using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class ReadAndShowText : MonoBehaviour
{
    public TMP_Text textField;
    private string filePathRead = "Assets/PromptBased/userpromptbased.json";

    // Start is called before the first frame update
    void Start()
    {
        FinalDataFormat data = ReadJsonFile();
        string loc = data.location;
        string sit = data.situation;
        string fee = data.feeling;
        textField.text = $"장소 - {loc}\n상황 - {sit}\n감정 - {fee}";
    }

    // Update is called once per frame
    void Update()
    {
    }

    private FinalDataFormat ReadJsonFile()
    {
        FileStream fileStream = new FileStream(filePathRead, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);
        FinalDataFormat returnedData = JsonUtility.FromJson<FinalDataFormat>(json);

        return returnedData;
    }
}
