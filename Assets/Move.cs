using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 vel;
    GameObject myObj;
    // Start is called before the first frame update
    void Start()
    {
        myObj = GameObject.FindGameObjectWithTag("InnerSphere");
        vel = new Vector3(0, 0, 1);


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + vel;
        if (transform.position.z > 300) {
            vel.z = -10;
        }
        else if (transform.position.z < 0) {
            vel.z = 10;
        }
    }
}
