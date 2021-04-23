using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text resultsText;
    [SerializeField]
    private GameObject backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (GameFinishVolume.gameCompleted == true)
        {
            resultsText.color = Color.green;
            resultsText.text = "GAME COMPLETED";
            // TODO: Change background image.
        }
        else if (GameFinishVolume.gameCompleted == false)
        {
            resultsText.color = Color.red;
            resultsText.text = "GAME OVER";
            // TODO: Change background image.
        }
    }
}
