using System;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class TrashGrabHandler : MonoBehaviour
{
    // public UnityEvent myEvent;
    public Action onGrabAction;
    private OVRGrabbable grabbable;

    private void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        System.Diagnostics.Debug.Assert(GetComponent<TrashGrabHandler>() != null);
        Debug.Log("yek");
    }

    private void Update()
    {
        if (grabbable.isGrabbed)
        {
            Debug.Log("object grabbed");
            onGrabAction.Invoke();
        }
    }
}