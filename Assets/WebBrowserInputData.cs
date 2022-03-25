using System.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RenderStreaming;
using Unity.WebRTC;
using Unity.RenderStreaming.Samples;
using UnityEngine.UI;


public class WebBrowserInputData : MonoBehaviour
{
    public MultiplayChannel multiplayChannel;
    public Multiplay multiplay;
    public InputField inputFMobile, inputFDesktop;
    private void Awake()
    {
        multiplay = FindObjectOfType<Multiplay>();
        inputFMobile.onEndEdit.AddListener(delegate { SendData(inputFMobile.text); });
        inputFDesktop.onEndEdit.AddListener(delegate { SendData(inputFDesktop.text); });
    }

    public void SendData(string msg)
    {
        //IPData ipData = new IPData();
        //ipData.ipAddress = "10.12.12.1";
        //ipData.port = ":80";
        //string sendIP = JsonUtility.ToJson(ipData);
        multiplayChannel.Channel.Send(msg);
        Debug.Log("ID" + multiplayChannel.Channel.Id);
        Debug.Log("Label" + multiplayChannel.Channel.Label);
        multiplay.Disconnect(multiplayChannel.connectionID_Temp);
    }
}

public class IPData
{
    public string ipAddress;
    public string port;
}
