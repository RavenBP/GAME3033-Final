using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Object : MonoBehaviour
{
    public ObjectType objectType;

    [SerializeField]
    private Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        switch(objectType)
        {
            case ObjectType.Red:
                gameObject.GetComponent<MeshRenderer>().material = materials[0];
                break;
            case ObjectType.Green:
                gameObject.GetComponent<MeshRenderer>().material = materials[1];
                break;
            case ObjectType.Blue:
                gameObject.GetComponent<MeshRenderer>().material = materials[2];
                break;
            case ObjectType.Yellow:
                gameObject.GetComponent<MeshRenderer>().material = materials[3];
                break;
            case ObjectType.Black:
                gameObject.GetComponent<MeshRenderer>().material = materials[4];
                break;
            case ObjectType.White:
                gameObject.GetComponent<MeshRenderer>().material = materials[5];
                break;
        }
    }
}
