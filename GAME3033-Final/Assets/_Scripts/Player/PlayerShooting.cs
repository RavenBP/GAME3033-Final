using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private void Update()
    {
        if (InputManager.Instance.PlayerShootingThisFrame() && PlayerController.gamePaused == false)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.GetComponent<Object>())
                {
                    this.gameObject.GetComponent<PlayerController>().objectType = hit.transform.gameObject.GetComponent<Object>().objectType;
                    this.gameObject.GetComponent<PlayerController>().ChangeType();
                }
                else if (hit.transform.GetComponent<Target>())
                {
                    hit.transform.gameObject.GetComponent<Target>().TargetHit();
                }
            }
            else
            {
                Debug.Log("I'm looking at nothing!");
            }

            audioSource.Play();
        }
    }
}
