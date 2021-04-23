using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private bool touchingSpikes = false;

    private IEnumerator DealDamage(PlayerController playerController)
    {
        playerController.currentHealth -= 15;
        playerController.playerUI.UpdateHealthText();

        yield return new WaitForSeconds(1.0f);

        if (touchingSpikes == true)
        {
            StartCoroutine(DealDamage(playerController));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerController>().objectType != ObjectType.Red)
            {
                touchingSpikes = true;

                StartCoroutine(DealDamage(other.GetComponent<PlayerController>()));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            touchingSpikes = false;

            StopCoroutine(DealDamage(other.GetComponent<PlayerController>()));
        }
    }
}
