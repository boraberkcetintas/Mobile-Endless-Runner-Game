using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedV; // İleri koşu hızı.
    [SerializeField] float speedH; // Sağa ve Sola gitme hızı.
    public DynamicJoystick dynamicJoystick; // Sağa ve Sola gitmek için gerekli Joystick.
    private Vector3 vectorHorizontal;
    private Vector3 speedXVec;
    public GManager gManagerScript;
    public Text scoreText;
    public float score;
    public Text inGameScoreText;
    private bool isHitToObstacle = false;

    private void Start()
    {
        speedXVec = new Vector3(speedH, 0f, 0f);
        gManagerScript = GameObject.Find("Game Manager").GetComponent<GManager>();
        Ragdollonoff(false);
    }
    private void FixedUpdate()
    {
        if (gManagerScript.state == GManager.GameState.Playing) // Eğer oyun "Playing" durumdaysa Move() çalıştır.
        {
            Move();
            score = Mathf.Round(transform.position.z);
            inGameScoreText.text = string.Format("{0} M", score);
        }
        else if (gManagerScript.state == GManager.GameState.Dead)
        {
            scoreText.text = string.Format("{0} M", score); //float score değerini sonuna M ekleyerek string hale çeviriyor.
        }
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
        if (transform.position.x > 2f)
        {
            transform.localPosition = new Vector3(2f, transform.localPosition.y, transform.localPosition.z);
        }

        //Karakter platform dışına çıkarsa, platform sınırına geri dönsün. (Sol)
        if (transform.position.x < -2f)
        {
            transform.localPosition = new Vector3(-2f, transform.localPosition.y, transform.localPosition.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle" && !isHitToObstacle )
        {
            Ragdollonoff(true);
            speedV = 0;
            speedXVec = new Vector3(0f, 0f, 0f);
            gManagerScript.UpdateGameState(GManager.GameState.Dead);
            isHitToObstacle = true;
        }
    }

    public GameObject[] ragdollgo;
    public void Ragdollonoff(bool control)
    {

        gameObject.GetComponent<Animator>().enabled = !control;


        for (int i = 0; i < ragdollgo.Length; i++)
        {

            ragdollgo[i].GetComponent<Rigidbody>().isKinematic = !control;
            ragdollgo[i].GetComponent<Rigidbody>().useGravity = control;
            ragdollgo[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (i == 0)
            {

                ragdollgo[i].GetComponent<BoxCollider>().enabled = control;
                if (control)
                {
                    ragdollgo[i].GetComponent<Rigidbody>().AddExplosionForce(500f, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), 5f);

                }

            }
            else if (i == 1)
            {
                ragdollgo[i].GetComponent<BoxCollider>().enabled = control;
            }
            else if (i > 1 && i < 10)
            {
                ragdollgo[i].GetComponent<CapsuleCollider>().enabled = control;
            }
            else
            {
                ragdollgo[i].GetComponent<SphereCollider>().enabled = control;
                if (control)
                {
                    if (transform.position.x > 0)
                    {
                        ragdollgo[i].GetComponent<Rigidbody>().AddForce(Vector3.right * 1000f);
                    }
                    else
                    {
                        ragdollgo[i].GetComponent<Rigidbody>().AddForce(Vector3.left * 1000);
                    }
                    ragdollgo[i].GetComponent<Rigidbody>().AddForce(Vector3.forward * 5000f);
                }
            }
        }
    }
}
