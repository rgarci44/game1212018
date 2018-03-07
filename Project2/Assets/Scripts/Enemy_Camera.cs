using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Enemy_Camera : MonoBehaviour
{

    private AudioSource weaponAudioSource;
    public LayerMask PlayerLayer;
    public LayerMask WaypointLayerLeft;
    public LayerMask WaypointLayerRight;
    public GameObject Player;
    public GameObject WaypointLeft;
    public GameObject WaypointRight;
    public GameObject Appendage;
    public Rigidbody Enemy_Bullet;
    public GameObject Gun;
    public float rotationSpeed = 180f;
    public float moveSpeed = 4.0f;
    public float radiusOfApproach = 50.0f;
    private float leftWall = 0.0f;
    private float rightWall = 0.0f;
    private bool attack = false;
    public float speed = 4.0f;
    private bool turn = false;
    public static bool alive = true;



    // Use this for initialization
    void Start()
    {
        weaponAudioSource = GameObject.Find("Enemy_Gun").GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
       

        if (FPS_Script.playable)
        {

            if (alive)
            {

                if (Vector3.Distance(Player.transform.position, transform.position) >= radiusOfApproach)
                {
                    findPlayer();
                }

            }
        }

    }


    private void findPlayer()
    {

        RaycastHit hitInfo;


        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 10f, PlayerLayer))
        {

            attackPlayer();



        }

        else if (Physics.Raycast(transform.position, -transform.right, out hitInfo, 10f, PlayerLayer))
        {

            attackPlayer();


        }


        // Go down
        else if (Physics.Raycast(transform.position, -transform.forward, out hitInfo, 10f, PlayerLayer))
        {

            attackPlayer();


        }


        else if (Physics.Raycast(transform.position, transform.right, out hitInfo, 10f, PlayerLayer))
        {

            attackPlayer();

        }

        else
        {
            
            Patrol();
        }



    }
    private void attackPlayer()
    {
       
        transform.LookAt(Player.transform.position);
        if (!attack)
        {
            StartCoroutine(fireRate());

        }

    }


    IEnumerator fireRate()
    {

        attack = true;
        Rigidbody clone;
        clone = Instantiate(Enemy_Bullet, Gun.transform.position, transform.rotation) as Rigidbody;
        clone.velocity = transform.TransformDirection(Vector3.forward * 10);
        weaponAudioSource.Play();
        yield return new WaitForSeconds(0.5F);
        attack = false;
    }



    private void Patrol()
    {

       
        Vector3 moveDirection = Vector3.zero;
        RaycastHit hitInfo;
        moveDirection += transform.forward;

        if (!turn)
        {
            transform.LookAt(WaypointLeft.transform.position);
        }

        if (turn)
        {
            transform.LookAt(WaypointRight.transform.position);
        }

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 1f, WaypointLayerLeft))
        {
            turn = true;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 1f, WaypointLayerRight))
        {
            turn = false;
        }

        transform.position += moveDirection.normalized * Time.deltaTime * speed;
    }

        }






