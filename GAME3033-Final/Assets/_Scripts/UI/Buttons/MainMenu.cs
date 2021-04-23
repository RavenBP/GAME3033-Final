using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private GameObject instructionsPanel;
    [SerializeField]
    private GameObject creditsPanel;

    public void Instructions()
    {
        instructionsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void ReturnToMainPanel()
    {
        mainPanel.SetActive(true);

        if (instructionsPanel.activeSelf == true)
        {
            instructionsPanel.SetActive(false);
        }
        else
        {
            creditsPanel.SetActive(false);
        }
    }
}
