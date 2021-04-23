using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBounds : MonoBehaviour
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
            audioSource.Play();

            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.gameObject.transform.position = respawnPosition.position;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider>().size);
    }
}
