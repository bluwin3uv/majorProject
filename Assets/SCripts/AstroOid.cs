using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroOid : MonoBehaviour
{
    public float rotX, rotY, rotZ;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotX, rotY, rotZ);
    }
}
