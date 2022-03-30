using System.ComponentModel.Design.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RenderStreaming.Samples;
using UnityEngine.UI;

public class PlayerButtonManager : MonoBehaviour
{
    [SerializeField] private MultiplayChannel mChannel;
    [SerializeField] private PlayerController pController;

    public void PortTo81()
    {
        Debug.Log("user.ActionDevices: " + pController.playerInput.user.actions.devices.ToString());
        Debug.Log("user.ActionDevices: " + pController.playerInput.user);
    }

}
