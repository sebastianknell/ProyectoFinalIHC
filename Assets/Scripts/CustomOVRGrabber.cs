using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using UnityEngine;

public class CustomOVRGrabber : OVRGrabber
{
    public AudioSource audioSource;
    private GameManager gameManager;
 
    protected override void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<GameManager>();
        // audioSource = GetComponent<AudioSource>();
    }

    protected override void GrabBegin()
    {
        base.GrabBegin();
        if (grabbedObject != null)
        {
            audioSource.Play();
            gameManager.UpdatePoints();
            Destroy(grabbedObject);
        }
    }
}
