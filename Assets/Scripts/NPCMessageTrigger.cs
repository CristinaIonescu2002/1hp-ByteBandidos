using UnityEngine;
using UnityEngine.UI; // sau using TMPro; dacă folosești TextMeshPro

public class NPCMessageTrigger : MonoBehaviour
{
    [Header("UI Setup")]
    public GameObject messagePrefab;    // Prefab-ul textului de tutorial
    public Canvas globalCanvas;         // Referința la canvas-ul global
    public Vector3 textOffset = new Vector3(0, 50, 0);  // Offset pentru poziționarea textului

    [Header("Camera Reference")]
    public Camera associatedCamera;     // Camera specifică pentru acest NPC (seteaz-o în Inspector)

    private GameObject messageInstance; // Instanța textului creată la runtime

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Debug.Log("OnTriggerEnter2D cu: " + other.name);
            if(messageInstance == null && messagePrefab != null && globalCanvas != null)
            {
                // Instanțiază textul ca copil al canvas-ului global
                messageInstance = Instantiate(messagePrefab, globalCanvas.transform);
            }
            if(messageInstance != null)
            {
                messageInstance.SetActive(true);
                UpdateMessagePosition();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Debug.Log("OnTriggerExit2D cu: " + other.name);
            if(messageInstance != null)
            {
                messageInstance.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if(messageInstance != null && messageInstance.activeSelf)
        {
            UpdateMessagePosition();
        }
    }

    void UpdateMessagePosition()
    {
        // Folosește associatedCamera în loc de Camera.main
        if (associatedCamera == null)
        {
            Debug.LogWarning("Associated Camera nu este setată, folosind Camera.main");
            associatedCamera = Camera.main;
        }
        Vector3 worldPos = transform.position + textOffset;
        Vector3 screenPos = associatedCamera.WorldToScreenPoint(worldPos);
        RectTransform rt = messageInstance.GetComponent<RectTransform>();
        if(rt != null)
        {
            rt.position = screenPos;
        }
    }
}
