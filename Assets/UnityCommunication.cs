using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class UnityCommunication : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void setupConnection(string useWebSocket); //"message" is the parameter of jslib function


    public void SendToJS(string useWebSocket)
    {
        setupConnection(useWebSocket);
    }
}
