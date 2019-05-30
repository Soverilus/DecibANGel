using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmooth : MonoBehaviour
{
    Vector3 origV;
    Vector3 dirToTarget;
    float originalDistance;
    public GameObject myTarget;
    Quaternion origQ;
    Transform target;

    void Start()
    {
        origV = transform.localPosition;
        origQ = transform.localRotation;
        originalDistance = Vector3.Magnitude(transform.position);
    }

    void Update()
    {
        target = myTarget.transform;
        dirToTarget = Vector3.Normalize(target.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, myTarget.transform.rotation, 0.15f);
        transform.position = Vector3.Slerp(transform.position, dirToTarget * originalDistance, 0.15f);
    }
}
