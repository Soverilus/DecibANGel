using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualPosition : MonoBehaviour
{
    public GameObject me;
    Transform targTran;
    public float rotPercent;
    public float posPercent;

    void Start() {
    }

    void Update()
    {
        targTran = me.transform;
        transform.rotation = Quaternion.Slerp(transform.rotation, targTran.rotation, rotPercent);
        transform.position = Vector3.Slerp(transform.position, targTran.position, posPercent);
    }
}
