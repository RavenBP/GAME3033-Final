using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private Door door;

    public void TargetHit()
    {
        door.IncrementTargetsHit();
        door.TryOpen();

        Destroy(this.gameObject);
    }
}
