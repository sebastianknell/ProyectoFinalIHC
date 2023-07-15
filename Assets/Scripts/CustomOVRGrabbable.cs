using UnityEngine;

public class CustomOVRGrabbable: OVRGrabbable
{
    private GameManager gameManager;
    private OVRInput.Controller controller = OVRInput.Controller.All;
    private float vibrationDuration = 0.1f;
    private float vibrationIntensity = 0.2f;
    private AudioSource audioSource;
    private AudioClip grabClip;
    
    protected override void Start()
    {
        base.Start();
        gameManager = FindObjectOfType<GameManager>();
        // audioSource = gameObject.AddComponent<AudioSource>();
        // audioSource = GetComponent<AudioSource>();
        // grabClip = Resources.Load("Interaction_BasicGrab_Grab_01") as AudioClip; 
    }

    override public void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        // OVRInput.SetControllerVibration(vibrationIntensity, vibrationIntensity, controller);
        // audioSource.PlayOneShot(grabClip);
        // Invoke("StopVibration", vibrationDuration);
        // gameManager.UpdatePoints();
        Destroy(gameObject);
    }
    
    override public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
    }
    
    private void StopVibration()
    {
        // Detener la vibración
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}