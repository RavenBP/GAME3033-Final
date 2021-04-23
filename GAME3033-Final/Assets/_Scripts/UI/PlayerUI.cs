using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerHealthText;

    public Image objectTypeImage;
    public TMP_Text objectTypeText;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        UpdateHealthText();
    }

    public void UpdateColor(Color newColor)
    {
        objectTypeImage.color = newColor;
        objectTypeText.text = playerController.objectType.ToString();
    }

    public void UpdateHealthText()
    {
        playerHealthText.text = $"HP: {Mathf.Clamp(playerController.currentHealth, 0, playerController.maximumHealth)} / {playerController.maximumHealth}";

        if (playerController.currentHealth <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("ResultsScene");
        }
    }
}
