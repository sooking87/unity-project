using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class StartProgram : MonoBehaviour
{
    int i = 1;
    DynamoDBContext context;
    CognitoAWSCredentials credentials;
    AmazonDynamoDBClient client;
    private void Awake()
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:e82049c3-f74c-430c-a105-e9e8b9b5ebde", RegionEndpoint.APNortheast2);
        client = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(client);
    }
    [DynamoDBTable("BlackOut_PromptBased_Text")]
    public class PromptInfo
    {
        [DynamoDBHashKey]
        public string id { get; set; }
        [DynamoDBProperty]
        public string gender { get; set; }
        [DynamoDBProperty]
        public string age { get; set; }
        [DynamoDBProperty]
        public string location { get; set; }
        [DynamoDBProperty]
        public string situation { get; set; }
        [DynamoDBProperty]
        public string feeling { get; set; }
    }

    public void UploadDataToDB()
    {
        FinalDataFormat data = ReadJsonFile();
        PromptInfo info = new PromptInfo
        {
            id = i.ToString(),
            gender = data.gender,
            age = data.age,
            location = data.location,
            situation = data.situation,
            feeling = data.feeling,
        };
        context.SaveAsync(info, (result) =>
        {
            // ¾÷·Îµå
            if (result.Exception == null)
            {
                Debug.Log("success!!!");
                i++;
            }
            else
            {
                Debug.Log(result.Exception.Message);
            }
        });
    }

    private FinalDataFormat ReadJsonFile()
    {
        FileStream fileStream = new FileStream("Assets/PromptBased/userpromptbased.json", FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string json = Encoding.UTF8.GetString(data);
        FinalDataFormat returnedData = JsonUtility.FromJson<FinalDataFormat>(json);

        return returnedData;
    }
}
