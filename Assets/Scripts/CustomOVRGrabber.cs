using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomOVRGrabber : OVRGrabber
{
    private GameManager gameManager;
    // private AudioSource audioSource;
 
    protected override void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<GameManager>();
        // audioSource = GetComponent<AudioSource>();
    }

    protected override void GrabBegin()
    {
        base.GrabBegin();
        // audioSource.Play();
        gameManager.UpdatePoints();
    }
}
