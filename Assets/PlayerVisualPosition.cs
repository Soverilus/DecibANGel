using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualPosition : MonoBehaviour
{
    public GameObject me;
    public Transform lookTarget;
    Transform targTran;
    void Start()
    {
        
    }

    void Update()
    {
        targTran = me.transform;
        transform.rotation = Quaternion.Slerp(transform.rotation, targTran.rotation, 0.25f);
        transform.position = Vector3.Slerp(transform.position, targTran.position, 0.25f);
    }
}
