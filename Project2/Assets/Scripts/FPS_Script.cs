using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Script : MonoBehaviour {

    private AudioSource switchAudioSource;
    public GameObject Appendage;
    public GameObject Camera;
    public GameObject Gun;
    public float speed = 4.0f;
    public float rotationSpeed = 90f;
    public static FPS_Script Instance;
    public static bool playable = true;
    public static bool machGun = false;
    public static bool switchGun = false;
    //public float rotationConstrict = 0f;
    public float constrainDistance = 10;
    // Use this for initialization
    void Start () {

        switchAudioSource = GameObject.Find("Player_Gun").GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if (playable)
        {
            CharacterMovement();
        }
	}


    void CharacterMovement()
    {

       

        Vector3 moveDirection = Vector3.zero;


        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -Appendage.transform.forward;

        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Appendage.transform.forward;

        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Appendage.transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -Appendage.transform.right;
        }
        moveDirection.y = 0;
        if (moveDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + moveDirection);
        }

      
        transform.position += moveDirection.normalized * Time.deltaTime * speed;

       

        if (transform.position.x > constrainDistance)
        {
            transform.position = new Vector3(constrainDistance, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -constrainDistance)
        {
            transform.position = new Vector3(-constrainDistance, transform.position.y, transform.position.z);
        }

        if (transform.position.z > constrainDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, constrainDistance);
        }
        if (transform.position.z < -constrainDistance)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -constrainDistance);
        }

       // if (transform.position.y > 0 || transform.position.y < 0)
       // {
       //     transform.position = new Vector3(transform.position.x, 0, transform.position.z);
       // }


        if (machGun)
        {
            if ((Input.GetMouseButtonDown(1)) && switchGun == true)
            {
                switchAudioSource.Play();
                Camera_Script.ammo = Camera_Script.regGunClip;
                switchGun = false;

            }

            else if ((Input.GetMouseButtonDown(1)) && switchGun == false)
            {
                switchAudioSource.Play();
                Camera_Script.ammo = Camera_Script.machGunClip;
                switchGun = true;

            }
        }


    }
}
