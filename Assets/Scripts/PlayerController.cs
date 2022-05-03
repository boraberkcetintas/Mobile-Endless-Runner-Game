using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedV; // İleri koşu hızı.
    [SerializeField] float speedH; // Sağa ve Sola gitme hızı.
    public DynamicJoystick dynamicJoystick; // Sağa ve Sola gitmek için gerekli Joystick.
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
        if (gManagerScript.state == GManager.GameState.Playing) // Eğer oyun "Playing" durumdaysa Move() çalıştır.
        {
            Move();
        };
    }

    void Move() // VerticalMove() ve HorizontalMove() çalıştır.
    {
        VerticalMove();
        HorizontalMove();
    }

    void VerticalMove()
    {
        // Karakteri zamana bağlı şekilde +z doğrusunda ilerlet.
        transform.Translate(Vector3.forward.normalized * speedV * Time.deltaTime); 
    }

    void HorizontalMove()
    {
        vectorHorizontal = speedXVec * dynamicJoystick.Horizontal * Time.deltaTime;


        // Karakter platform sınırları içerisindeyse haraket etsin.
        if (transform.localPosition.x <= 2f && transform.localPosition.x >= -2f)
        {
            transform.position += vectorHorizontal;
        }


        //Karakter platform dışına çıkarsa, platform sınırına geri dönsün. (Sağ)
        if(transform.position.x > 2f)
        {
            transform.localPosition = new Vector3(2f, transform.localPosition.y, transform.localPosition.z);
        }

        //Karakter platform dışına çıkarsa, platform sınırına geri dönsün. (Sol)
        if (transform.position.x < -2f)
        {
            transform.localPosition = new Vector3(-2f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
