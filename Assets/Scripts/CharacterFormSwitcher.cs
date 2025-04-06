using UnityEngine;

public class CharacterFormSwitcher : MonoBehaviour
{
    [Header("Player Identity")]
    public bool isPlayerOne = true; // true = Player1, false = Player2

    [Header("Current Form")]
    // true = Angel, false = Demon (setat corespunzător în Inspector pentru forma inițială)
    public bool isAngel = true;

    [Header("Prefab References for Player1")]
    public GameObject player1AngelPrefab;
    public GameObject player1DemonPrefab;

    [Header("Prefab References for Player2")]
    public GameObject player2AngelPrefab;
    public GameObject player2DemonPrefab;

    [Header("Camera Reference")]
    // Referința la componenta CameraFollow aferentă jucătorului (nu folosi Camera.main)
    public CameraFollow myCameraFollow;

    // Optional: un offset la instanțiere (ex: un pas în față)
    public Vector3 spawnOffset = Vector3.zero;

    // Variabilă statică folosită doar în Singleplayer pentru a reține care instanță e controlată
    public static bool controlledIsPlayerOne = true;

    // Flag-ul care indică dacă acest obiect procesează input (în Singleplayer)
    public bool isControlled = true;

    // Variabilă statică pentru a procesa tasta de switch control o singură dată per cadru
    private static int lastControlSwitchFrame = -1;

    void Start()
    {
        if (GlobalVariables.GAME_MODE == "Singleplayer")
        {
            // La început, doar instanța care are isPlayerOne egal cu controlledIsPlayerOne va fi controlată
            isControlled = (isPlayerOne == controlledIsPlayerOne);
            Debug.Log(gameObject.name + " Start: isControlled = " + isControlled);
        }
        // În modul Coop, se presupune că fiecare instanță este controlată independent (setate manual în Inspector)
    }

    void Update()
    {
        if (!isControlled)
            return; // Dacă nu ești controlat, ieși din Update
        if (GlobalVariables.GAME_MODE == "Singleplayer")
        {
            // Doar instanța cu isPlayerOne == true procesează tasta SPACE pentru comutarea controlului.
            if (isPlayerOne && Input.GetKeyDown(GlobalVariables.SWITCH) && Time.frameCount != lastControlSwitchFrame)
            {
                lastControlSwitchFrame = Time.frameCount;
                controlledIsPlayerOne = !controlledIsPlayerOne;
                Debug.Log("Switch control pressed. New controlledIsPlayerOne = " + controlledIsPlayerOne);
            }
            else 
            {
                // Dacă nu ești Player1, dar ai apăsat tasta de switch control, ieși din Update
                if (!isPlayerOne && Input.GetKeyDown(GlobalVariables.SWITCH))
                {
                    return;
                }
            }

            // Actualizează flag-ul de control pentru această instanță
            isControlled = (isPlayerOne == controlledIsPlayerOne);
            Debug.Log(gameObject.name + " Update: isControlled = " + isControlled);

            // Apelăm switch form doar pentru instanța controlată
            if (isControlled && Input.GetKeyDown(GlobalVariables.P1_SWITCHFORM))
            {
                if (this.gameObject.name.Contains("Devil") && GlobalVariables.P1_inventory == 3) {
                        SwitchForm();
                    } else if (this.gameObject.name.Contains("Angel") 
                    && (GlobalVariables.P1_inventory == 1 || GlobalVariables.P1_inventory == 2)) {
                        SwitchForm();
                    }

            }
        }
        else // Modul Coop
        {
            if (isPlayerOne)
            {
                if (!string.IsNullOrEmpty(GlobalVariables.P1_SWITCHFORM) && Input.GetKeyDown(GlobalVariables.P1_SWITCHFORM))
                {
                    if (this.gameObject.name.Contains("Devil") && GlobalVariables.P1_inventory == 3) {
                        SwitchForm();
                    } else if (this.gameObject.name.Contains("Angel") 
                    && (GlobalVariables.P1_inventory == 1 || GlobalVariables.P1_inventory == 2)) {
                        SwitchForm();
                    }

                    GlobalVariables.P1_inventory = 0;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(GlobalVariables.P2_SWITCHFORM) && Input.GetKeyDown(GlobalVariables.P2_SWITCHFORM))
                {
                    if (this.gameObject.name.Contains("Devil") && GlobalVariables.P2_inventory == 3) {
                        SwitchForm();
                    } else if (this.gameObject.name.Contains("Angel") 
                    && (GlobalVariables.P2_inventory == 1 || GlobalVariables.P2_inventory == 2)) {
                        SwitchForm();
                    }

                    GlobalVariables.P2_inventory = 0;
                }
            }
        }
    }



    public void SwitchForm()
    {
        // Salvează poziția curentă plus offset și rotația
        Vector3 currentPos = transform.position + spawnOffset;
        Quaternion currentRot = transform.rotation;
        
        // Salvează velocity-ul curent, dacă există
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 currentVelocity = rb != null ? rb.linearVelocity : Vector2.zero;
        
        // Determină noul prefab, în funcție de identitatea jucătorului și forma curentă
        GameObject newPrefab = null;
        if (isPlayerOne)
        {
            newPrefab = isAngel ? player1DemonPrefab : player1AngelPrefab;
        }
        else
        {
            newPrefab = isAngel ? player2DemonPrefab : player2AngelPrefab;
        }
        if (newPrefab == null)
        {
            Debug.LogError("New prefab is not set correctly!");
            return;
        }
        
        // Instanțiază noul obiect la poziția și rotația salvate
        GameObject newForm = Instantiate(newPrefab, currentPos, currentRot);
        
        // Transferă velocity-ul dacă există
        Rigidbody2D newRb = newForm.GetComponent<Rigidbody2D>();
        if (newRb != null)
        {
            newRb.linearVelocity = currentVelocity;
        }
        
        // Actualizează target-ul camerei folosind referința specifică
        if (myCameraFollow != null)
        {
            myCameraFollow.target = newForm.transform;
        }
        else
        {
            Debug.LogWarning("myCameraFollow is not set!");
        }
        
        // Transferă flag-ul de control la noua instanță pe scriptul de switch
        CharacterFormSwitcher newSwitcher = newForm.GetComponent<CharacterFormSwitcher>();
        if (newSwitcher != null)
        {
            newSwitcher.isPlayerOne = this.isPlayerOne;
            newSwitcher.isAngel = !this.isAngel; // Inversează forma (switch bidirecțional)
            newSwitcher.myCameraFollow = this.myCameraFollow;
            if (GlobalVariables.GAME_MODE == "Singleplayer")
            {
                newSwitcher.isControlled = this.isControlled; // Transferă controlul
            }
        }
        
        // Transferă flag-ul de control și la componenta de mișcare (AngelMovement sau DevilMovement)
        AngelMovement newAngel = newForm.GetComponent<AngelMovement>();
        if (newAngel != null)
        {
            newAngel.isControlled = this.isControlled;
        }
        DevilMovement newDevil = newForm.GetComponent<DevilMovement>();
        if (newDevil != null)
        {
            newDevil.isControlled = this.isControlled;
        }
        
        // Distruge vechiul obiect (forma curentă)
        Destroy(gameObject);
    }

}
