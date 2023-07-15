using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class TrashPickup : MonoBehaviour
{
    public int points = 10;

    private OVRGrabbable grabbable;

    private void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        // grabbable.GrabBegin += OnGrabBegin;
        // grabbable.GrabEnd += OnGrabEnd;
    }

    private void OnGrabBegin()
    {
        // Aquí puedes realizar cualquier lógica adicional al agarrar la basura.
    }

    private void OnGrabEnd()
    {
        if (grabbable.isGrabbed)
            return;

        // Verificar si la basura está dentro del área de recolección
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("PickupArea"))
            {
                // Aumentar los puntos cuando la basura se suelta dentro del área de recolección
                // ScoreManager.Instance.AddPoints(points);
                // Destruir el objeto de basura
                Destroy(gameObject);
                break;
            }
        }
    }
}

