using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishingCube : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPosition;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().currentHealth -= 10;
            other.GetComponent<PlayerController>().playerUI.UpdateHealthText();

            audioSource.Play();

            other.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = respawnPosition.position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
