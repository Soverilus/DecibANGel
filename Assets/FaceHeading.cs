using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceHeading : MonoBehaviour
{
    Vector3 oldPos;
    Vector3 newPos;
    Vector3 targetPos;

    void Update()
    {
        newPos = transform.position;
        targetPos = Vector3.Normalize(oldPos + newPos);
        transform.LookAt(transform.position + targetPos*100, transform.position);
        oldPos = newPos;
    }
}
