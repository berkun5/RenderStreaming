using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.RenderStreaming.Samples;

public class IPPORTAssign : MonoBehaviour
{
    public TMP_InputField portIF;
    // Start is called before the first frame update
    private void Awake()
    {
        portIF.onEndEdit.AddListener(delegate { StaticPORT.port = portIF.text; });
    }


}
