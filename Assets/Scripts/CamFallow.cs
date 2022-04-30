using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFallow : MonoBehaviour
{
    public Vector3 offSet;
    public GameObject target;
    [Range(0f, 1f)] public float t;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offSet, t);
    }
}
