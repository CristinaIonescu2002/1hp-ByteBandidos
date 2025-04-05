using UnityEngine;

public class FormSwitcher : MonoBehaviour
{
    // Setezi în Inspector dacă e Player1 sau Player2
    public bool isPlayerOne = true;
    // Setezi în Inspector dacă e Blue sau Purple
    public string color = "Blue"; // "Blue" sau "Purple"
    // Setezi în Inspector dacă e Angel sau Devil
    public string form = "Angel"; // "Angel" sau "Devil"

    // Referință la scriptul de mișcare (pentru a prelua velocity, isControlled etc.)
    // Poți folosi o interfață comună sau direct un script. Exemplu:
    private Rigidbody2D rb;
    private AngelMovement angelMovement;    // dacă e angel
    private DevilMovement devilMovement;    // dacă e devil

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Dacă e Angel, preia scriptul AngelMovement (dacă îl ai). 
        // Dacă e Devil, preia scriptul DevilMovement, etc.
        angelMovement = GetComponent<AngelMovement>();
        devilMovement = GetComponent<DevilMovement>();
    }

    void Update()
    {
        // Verificăm ce tastă folosește acest jucător
        if (isPlayerOne)
        {
            if (!string.IsNullOrEmpty(GlobalVariables.P1_SWITCHFORM) && Input.GetKeyDown(GlobalVariables.P1_SWITCHFORM))
            {
                if ((angelMovement && angelMovement.isControlled) || (devilMovement && devilMovement.isControlled))
                {
                    SwitchForm();
                }
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(GlobalVariables.P2_SWITCHFORM) && Input.GetKeyDown(GlobalVariables.P2_SWITCHFORM))
            {
                if ((angelMovement && angelMovement.isControlled) || (devilMovement && devilMovement.isControlled))
                {
                    SwitchForm();
                }
            }
        }
    }

    void SwitchForm()
    {
        // Stabilim ce formă nouă instanțiem
        string newForm = (form == "Angel") ? "Devil" : "Angel";

        // Luăm poziția curentă și velocity
        Vector3 oldPos = transform.position;
        Vector2 oldVel = (rb != null) ? rb.linearVelocity : Vector2.zero;

        bool oldIsControlled = (angelMovement && angelMovement.isControlled) ||
                               (devilMovement && devilMovement.isControlled);

        // Determinăm prefab-ul pe care să-l instanțiem
        GameObject newPrefab = null;

        if (color == "Blue")
        {
            newPrefab = (newForm == "Angel") ? FormManager.Instance.BlueAngelPrefab
                                             : FormManager.Instance.BlueDevilPrefab;
        }
        else // color == "Purple"
        {
            newPrefab = (newForm == "Angel") ? FormManager.Instance.PurpleAngelPrefab
                                             : FormManager.Instance.PurpleDevilPrefab;
        }

        // Instanțiem noul obiect la aceeași poziție
        GameObject newObj = Instantiate(newPrefab, oldPos, Quaternion.identity);

        // Preluăm Rigidbody2D de pe noul obiect, îi setăm velocity
        Rigidbody2D newRb = newObj.GetComponent<Rigidbody2D>();
        if (newRb != null)
        {
            newRb.linearVelocity = oldVel;
        }

        // Marcam dacă e controlat
        // Exemplu, dacă e AngelMovement pe noul, setăm isControlled = oldIsControlled
        AngelMovement newAngelMov = newObj.GetComponent<AngelMovement>();
        if (newAngelMov != null) newAngelMov.isControlled = oldIsControlled;

        DevilMovement newDevilMov = newObj.GetComponent<DevilMovement>();
        if (newDevilMov != null) newDevilMov.isControlled = oldIsControlled;

        // Distrugem obiectul vechi
        Destroy(gameObject);
    }
}
