using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject target;
    public GameObject target2;
    float yPos;
    float zPos;
    public float yPosModify;
    
    void Start()
    {
        yPos = gameObject.transform.position.y;
        
        yPosModify = -0.5f;
    }

    void OnTriggerEnter(Collider col) // Lowers the y axis position of the switch to emulate it being pressed down
    {
        if (col.gameObject.tag == ("Player"))
        {
            gameObject.transform.Translate(0, 0, yPosModify);
            Destroy(gameObject.GetComponent<BoxCollider>());
            target.SetActive(false);
            target2.SetActive(false);
        }
    }

}
