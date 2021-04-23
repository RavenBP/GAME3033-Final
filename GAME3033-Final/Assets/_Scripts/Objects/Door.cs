using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Target[] targets;

    private int targetsHit;

    private void Start()
    {
        targetsHit = 0;
    }

    public void IncrementTargetsHit()
    {
        targetsHit++;
    }

    public void TryOpen()
    {
        if (targetsHit == targets.Length)
        {
            // Open the door
            Destroy(this.gameObject);
        }
    }
}
