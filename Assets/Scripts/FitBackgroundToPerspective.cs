using UnityEngine;

public class FitBackgroundToPerspective : MonoBehaviour
{
    // Assign your perspective camera in the Inspector or leave it empty to auto-assign Camera.main
    public Camera mainCamera;
    
    // Distance from the camera where you want the background to be placed
    public float distanceFromCamera = 10f;

    void Start()
    {
        // If no camera is assigned, use the main camera
        if (mainCamera == null)
            mainCamera = Camera.main;
        
        // Get the SpriteRenderer attached to this GameObject
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null || sr.sprite == null)
        {
            Debug.LogError("Missing SpriteRenderer or Sprite!");
            return;
        }

        // Calculate the visible height at the specified distance from the perspective camera.
        // Formula: height = 2 * distance * tan(FOV/2)
        float frustumHeight = 2f * distanceFromCamera * Mathf.Tan(mainCamera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        // Calculate the visible width based on the camera's aspect ratio.
        float frustumWidth = frustumHeight * mainCamera.aspect;

        // Get the sprite's size in world units
        Vector2 spriteSize = sr.sprite.bounds.size;

        // Calculate the scale factors so that the sprite covers the entire camera view.
        Vector3 newScale = transform.localScale;
        newScale.x = frustumWidth / spriteSize.x;
        newScale.y = frustumHeight / spriteSize.y;
        transform.localScale = newScale;

        // Position the background directly in front of the camera along its forward direction.
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCamera;
    }
}
