using UnityEngine;
using Util;

public class SmoothCamera2D : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Update is called after all other updates
    void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        //Linear Interpolation (Takes Current Position to desired position)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothSpeed);
        transform.position = smoothedPosition;    
    }

}
