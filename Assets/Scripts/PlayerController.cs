using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedV;
    [SerializeField] float speedH;
    public DynamicJoystick dynamicJoystick;
    private Vector3 vectorHorizontal;
    private Vector3 speedXVec;
    public GManager gManagerScript;

    public void Start()
    {
       speedXVec = new Vector3(speedH, 0f, 0f);
        gManagerScript = GameObject.Find("Game Manager").GetComponent<GManager>();
    }
    private void FixedUpdate()
    {
        if (gManagerScript.state == GManager.GameState.Playing) 
        {
            Move();
        };
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
        vectorHorizontal = speedXVec * dynamicJoystick.Horizontal * Time.deltaTime;

        if (transform.localPosition.x <= 2f && transform.localPosition.x >= -2f)
        {
            transform.position += vectorHorizontal;
        }

        if(transform.position.x > 2f)
        {
            transform.localPosition = new Vector3(2f, transform.localPosition.y, transform.localPosition.z);
        }

        if (transform.position.x < -2f)
        {
            transform.localPosition = new Vector3(-2f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
