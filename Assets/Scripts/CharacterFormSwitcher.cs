using UnityEngine;

public class CharacterFormSwitcher : MonoBehaviour
{
    // Referințe la cele două forme
    public GameObject angelForm;
    public GameObject demonForm;

    // Tasta de switch
    public KeyCode switchKey = KeyCode.LeftShift;

    // Starea curentă (true = angel, false = demon)
    private bool isAngel = true;

    void Start()
    {
        // La început, asigură-te că doar forma de angel este activă
        if (angelForm != null && demonForm != null)
        {
            angelForm.SetActive(true);
            demonForm.SetActive(false);
        }
    }

    void Update()
    {
        // Apasă tasta de switch pentru a schimba forma, dar doar dacă forma curentă este Angel
        if (Input.GetKeyDown(switchKey) && isAngel)
        {
            SwitchToDemon();
        }
        // Dacă dorești switch bidirecțional, poți adăuga și cod pentru transformarea în Angel din Demon.
    }

    void SwitchToDemon()
    {
        if (angelForm != null && demonForm != null)
        {
            // Dezactivează forma de Angel și activează forma de Demon
            angelForm.SetActive(false);
            demonForm.SetActive(true);
            isAngel = false;
            Debug.Log("Switch: Character transformed from Angel to Demon.");
        }
    }
}
