using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Apple image")]
    public GameObject apple_image_up;
    public GameObject apple_image_down;

    [Header("Pitchfork image")]
    public GameObject pitchfork_image_up;
    public GameObject pitchfork_image_down;


    [Header("Flower image")]
    public GameObject flower_image_up;
    public GameObject flower_image_down;


    void Start()
    {
        GlobalVariables.P1_inventory = 0;
        GlobalVariables.P2_inventory = 0;

        apple_image_up.SetActive(false);
        pitchfork_image_up.SetActive(false);
        flower_image_up.SetActive(false);

        apple_image_down.SetActive(false);
        pitchfork_image_down.SetActive(false);
        flower_image_down.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AAAA-" + GlobalVariables.P1_inventory + "-" + GlobalVariables.P2_inventory);
        if (GlobalVariables.P1_inventory > 0) {

            switch (GlobalVariables.P1_inventory){
                case 1: 
                    apple_image_up.SetActive(true); 
                    pitchfork_image_up.SetActive(false);
                    flower_image_up.SetActive(false);
                    break;
                case 2: 
                    apple_image_up.SetActive(false);
                    pitchfork_image_up.SetActive(true); 
                    flower_image_up.SetActive(false);
                    break;
                case 3: 
                    apple_image_up.SetActive(false);
                    pitchfork_image_up.SetActive(false);
                    flower_image_up.SetActive(true); 
                    break;
            }

        } else {
            apple_image_up.SetActive(false);
            pitchfork_image_up.SetActive(false);
            flower_image_up.SetActive(false);
        }

        if (GlobalVariables.P2_inventory > 0) {

            switch (GlobalVariables.P2_inventory){
                case 1: 
                    apple_image_down.SetActive(true); 
                    pitchfork_image_down.SetActive(false);
                    flower_image_down.SetActive(false);
                    break;
                case 2: 
                    apple_image_down.SetActive(false);
                    pitchfork_image_down.SetActive(true); 
                    flower_image_down.SetActive(false);
                    break;
                case 3: 
                    apple_image_down.SetActive(false);
                    pitchfork_image_down.SetActive(false);
                    flower_image_down.SetActive(true); 
                    break;
            }

        } else {
            apple_image_down.SetActive(false);
            pitchfork_image_down.SetActive(false);
            flower_image_down.SetActive(false);
        }
    }

    public void Destroy ()
    {

    }
}
