using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Referință la caracterul pe care vrei să-l urmărești
    public Vector3 offset;          // Offset-ul (distanța) dintre cameră și caracter
    public float smoothSpeed = 0.125f; // Viteza de netezire a mișcării camerei (opțional)

    void LateUpdate()
    {
        // Calculăm poziția dorită ca suma poziției caracterului și a offset-ului
        Vector3 desiredPosition = target.position + offset;
        // Calculăm o poziție netezită între poziția actuală și cea dorită
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Setăm poziția camerei la poziția netezită
        transform.position = smoothedPosition;
    }
}
