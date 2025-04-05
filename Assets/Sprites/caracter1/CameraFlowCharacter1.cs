using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Referință la caracterul pe care vrei să-l urmărești
    public Vector3 offset;          // Offset-ul (distanța) dintre cameră și caracter
    public float smoothSpeed = 0.125f; // Viteza de netezire a mișcării camerei

    void LateUpdate()
    {
        if (target == null)
            return;
        
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
