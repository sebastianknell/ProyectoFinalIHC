using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticFeedback : MonoBehaviour
{
    public OVRInput.Controller controller = OVRInput.Controller.All;
    public float vibrationDuration = 0.1f;
    public float vibrationIntensity = 0.2f;
    private OVRGrabber grabber;
    
    private void Start()
    {
        // Iniciar el controlador de vibración en cero
        OVRInput.SetControllerVibration(0, 0, controller);
        grabber = GetComponent<OVRGrabber>();
    }

    private void Update()
    {
        // Detectar cuando se agarra el objeto
        // if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller))
        // {
        //     // Activar una vibración rápida y sutil en el controlador
        //     OVRInput.SetControllerVibration(vibrationIntensity, vibrationIntensity, controller);
        //     // Detener la vibración después de la duración especificada
        //     Invoke("StopVibration", vibrationDuration);
        // }
    }

    private void StopVibration()
    {
        // Detener la vibración
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}