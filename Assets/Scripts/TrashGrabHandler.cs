using System;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.Events;

public class TrashGrabHandler : MonoBehaviour
{
    private OVRGrabbable grabbable;
    private GameManager gameManager;

    private void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log("yek");
    }

    private void Update()
    {
        if (grabbable.isGrabbed)
        {
            Debug.Log("object grabbed");
            gameManager.UpdatePoints();
        }
    }
}