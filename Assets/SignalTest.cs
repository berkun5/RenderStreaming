using System;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using Unity.WebRTC;
using UnityEngine;
using WebSocketSharp;
using Unity.RenderStreaming.Signaling;
using UnityEngine.UI;

public class SignalTest : MonoBehaviour, ISignaling
{
    public void Start()
    {
        //throw new NotImplementedException();
        /*
        Button a = GetComponent<Button>();
        RTCSessionDescription ab = new RTCSessionDescription();
        ab.type = RTCSdpType.Offer;
        ab.sdp = "sdp";
        a.onClick.AddListener(delegate { SendOffer("adfgadfgdfg", ab); });*/
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public void OpenConnection(string connectionId)
    {
        throw new NotImplementedException();
    }

    public void CloseConnection(string connectionId)
    {
        //throw new NotImplementedException();
        Debug.Log("Closing Connection: SignalTest." + connectionId);
    }

    public void SendOffer(string connectionId, RTCSessionDescription offer)
    {
        throw new NotImplementedException();
    }

    public void SendAnswer(string connectionId, RTCSessionDescription answer)
    {
        throw new NotImplementedException();
    }

    public void SendCandidate(string connectionId, RTCIceCandidate candidate)
    {
        throw new NotImplementedException();
    }

    public string Url { get; }
    public float Interval { get; }
    public event OnStartHandler OnStart;
    public event OnConnectHandler OnCreateConnection;
    public event OnDisconnectHandler OnDestroyConnection;
    public event OnOfferHandler OnOffer;
    public event OnAnswerHandler OnAnswer;
    public event OnIceCandidateHandler OnIceCandidate;


}
