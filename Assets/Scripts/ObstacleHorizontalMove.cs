using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHorizontalMove : MonoBehaviour
{
    public float speed = 2.5f;
    public Vector3 boundryPositionPX = new Vector3(1.5f, 0, 2.5f); //pozitif x pozisyonu
    public Vector3 boundryPositionNX = new Vector3(-1.5f, 0, 2.5f); // negatif x pozisyonu

    void Update()
    {
        MoveHorizontal();
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }
    void MoveHorizontal() {
        if(transform.position.x < -1.5)
        {
            transform.localPosition = boundryPositionNX;
            speed = -speed;
        }

        if(transform.position.x > 1.5)
        {
            transform.localPosition = boundryPositionPX;
            speed = -speed;
        }
        
    }
}
