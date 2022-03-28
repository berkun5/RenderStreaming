using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.RenderStreaming.Samples;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Unity.RenderStreaming;
public class Button_Connect : Button
{

    [SerializeField] public string id;
    protected bool isHighlighted = false;
    protected bool isPressed = false;


    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        id = transform.root.GetComponent<MultiplayChannel>().connectionID_Temp;
        if (state == SelectionState.Pressed)
        {
            if (id != transform.root.GetComponent<MultiplayChannel>().connectionID_Temp) { Debug.Log("id != connectionidTemp: " + id); return; }

            EventSystem a = FindObjectOfType<EventSystem>();
            PointerEventData data = new PointerEventData(a);
            Debug.Log("id ===== connectionidTemp: " + id);
            base.OnPointerClick(data);
        }
    }
    private void Berk()
    {

    }
    public void OnMovement(InputAction.CallbackContext value)
    {
    }

    /*public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerId);
        base.OnPointerClick(eventData);
    }*/
}
