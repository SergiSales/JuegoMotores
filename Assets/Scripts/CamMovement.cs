using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
