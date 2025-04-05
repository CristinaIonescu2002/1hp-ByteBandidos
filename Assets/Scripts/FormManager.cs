using UnityEngine;

public class FormManager : MonoBehaviour
{
    public static FormManager Instance;

    public GameObject BlueAngelPrefab;
    public GameObject BlueDevilPrefab;
    public GameObject PurpleAngelPrefab;
    public GameObject PurpleDevilPrefab;

    void Awake()
    {
        // Asigură singleton (opțional)
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
