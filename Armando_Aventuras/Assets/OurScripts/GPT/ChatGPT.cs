using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using System;
using System.Text;
using System.IO;


public class ChatGPT : MonoBehaviour
{

    [SerializeField] private string APIKey;

    [TextArea(3, 18)]
    [SerializeField] private string prompt;

    [TextArea(3, 18)]
    [SerializeField] private string result;

    private readonly string chatGPTUrlAPI;
    private readonly string scriptsFolder = "Assets/OurScripts/GPT";
    private readonly string directory = "ChatGPT";

    RequestBodyChatGPT requestBodyChatGPT;

    public void SendRequest()
    {
        result = string.Empty;

        requestBodyChatGPT = new RequestBodyChatGPT();
        requestBodyChatGPT.model = "text-davinci-003";
        requestBodyChatGPT.prompt = prompt;
        requestBodyChatGPT.max_tokens = 2048;
        requestBodyChatGPT.temperature = 0;
    }

    private IEnumerator SendRequestAPI()
    {
        string jsonData = JsonUtility.ToJson(requestBodyChatGPT);
        byte[] rawData = Encoding.UTF8.GetBytes(jsonData);

        UnityWebRequest requestChatGPT = new UnityWebRequest(chatGPTUrlAPI,"POST");

        requestChatGPT.uploadHandler = new UploadHandlerRaw(rawData);
        requestChatGPT.downloadHandler = new DownloadHandlerBuffer();

        //-H "Content-Type: application/json" \
        //-H "Authorization: Bearer $OPENAI_API_KEY" \

        //TODO
        // https://youtu.be/RRGtluRf7ys?t=544
    }
}

[SerializeField]
public class RequestBodyChatGPT
{
    public string model;
    public string prompt;
    public int max_tokens;
    public int temperature;
}
