using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public DynamicJoystick dynamicJoy;
    public float speed;
    public float horizontalSpeed;
    private Vector3 horizontalVector;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (GameManager.GetInstance().state == GameManager.State.Playing)
        {
            VerticalMove();
        }
    }

    private void VerticalMove()
    {
        transform.position += Vector3.forward.normalized * speed * Time.deltaTime;

        HorizontalMove();
    }

    private void HorizontalMove()//-2 / 2
    {
        Vector3 horizonSpeed = new Vector3(horizontalSpeed, 0f, 0f);
        horizontalVector = dynamicJoy.Horizontal * horizonSpeed * Time.deltaTime;

        if (transform.localPosition.x <= -2f && horizontalVector.x > 0 || transform.localPosition.x >= 2f && horizontalVector.x < 0)
        {
            transform.position += horizontalVector;
        }

        if (transform.localPosition.x >= -2f && transform.localPosition.x <= 2f)
        {
            transform.position += horizontalVector;
        }
    }


    
}
