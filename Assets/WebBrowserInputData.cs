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

    /*public override void SetChannel(string connectionId, RTCDataChannel channel)
    {
        this.channel = channel;
        base.SetChannel(connectionId, channel);
        Debug.Log("SET CHANNEL: WebBrowserInputData");
    }*/

    public void SendData(string msg)
    {
        //IPData ipData = new IPData();
        //ipData.ipAddress = "10.12.12.1";
        //ipData.port = ":80";
        //string sendIP = JsonUtility.ToJson(ipData);
        multiplayChannel.Channel.Send(msg);
        Debug.Log("ID" + multiplayChannel.Channel.Id);
        Debug.Log("Label" + multiplayChannel.Channel.Label);
    }
}

public class IPData
{
    public string ipAddress;
    public string port;
}
