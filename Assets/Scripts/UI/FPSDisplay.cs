using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    private float pollingTime = 1f;
    private float time;
    private int frameCount;

    public void Update() 
    {
        if (!GlobalVariables.ShowFPSDetails) {
            FpsText.text = "";
        } else {
            time += Time.deltaTime;

            frameCount++;
            
            if (time >= pollingTime) {
                int frameRate = Mathf.RoundToInt(frameCount/time);

                FpsText.text = frameRate.ToString() + " FPS";

                time -= pollingTime;
                frameCount = 0;
            }
        }
    }
}
