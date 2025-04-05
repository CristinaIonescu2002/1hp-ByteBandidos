using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    [Header("FPS Toggle")]
    public GameObject fpsCheckmark;
    public void BackButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void ToggleFPS()
    {
        GlobalVariables.ShowFPSDetails = !GlobalVariables.ShowFPSDetails;
        fpsCheckmark.SetActive(GlobalVariables.ShowFPSDetails);

        if (fpsCheckmark != null)
            fpsCheckmark.SetActive(GlobalVariables.ShowFPSDetails);
    }
}
