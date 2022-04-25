using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedV;
    [SerializeField] float speedH;
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        VerticalMove();
        HorizontalMove();
    }

    void VerticalMove()
    {
        transform.Translate(Vector3.forward.normalized * speedV * Time.deltaTime); 
    }

    void HorizontalMove()
    {

    }
}
