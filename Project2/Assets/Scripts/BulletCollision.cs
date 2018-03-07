using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public AudioClip playerHitClip;
    public AudioClip playerDeathClip;

    private AudioSource playerAudioSource;
    private AudioSource enemyAudioSource;

    public Rigidbody Bullet;
    public Rigidbody Enemy_Bullet;
    
    public float constrainDistance = 10;
    public static int health = 100;
    // Use this for initialization
    void Start()
    {
        playerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        enemyAudioSource = GameObject.Find("Directional Light").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        WallCollision();

        if (health > 0)
        {
            playerAudioSource.clip = playerHitClip;

        }
        else
        {
            playerAudioSource.clip = playerDeathClip;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider otherCollider = collision.collider;
        GameObject otherObject = collision.gameObject;
        Transform otherTransform = collision.transform;
        Rigidbody otherRigidBody = collision.rigidbody;



        if (otherObject.tag == "Player")
        {
           
            playerAudioSource.Play();
            health -= 5;
            Destroy(GameObject.Find("Enemy_Bullet(Clone)"));
        }

        if (otherObject.tag == "Enemy")
        {
            enemyAudioSource.Play();
            Enemy_Camera.alive = false;
            Destroy(GameObject.Find("Enemy"));
        }
        //print("Object " + transform.name + " collided with " + collision.gameObject.name);
        Destroy(GameObject.Find("Bullet(Clone)"));
        Destroy(GameObject.Find("Enemy_Bullet(Clone)"));

    }


    private void WallCollision()
    {
        if (Bullet.position.x > constrainDistance)
        {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }
        if (Bullet.position.x < -constrainDistance)
        {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }

        if (Bullet.position.z > constrainDistance)
        {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }
        if (Bullet.position.z < -constrainDistance)
        {
            Destroy(GameObject.Find("Bullet(Clone)"));
        }


        if (Enemy_Camera.alive)
        {
            if (Enemy_Bullet.position.x > constrainDistance)
            {
                Destroy(GameObject.Find("Enemy_Bullet(Clone)"));
            }
            if (Enemy_Bullet.position.x < -constrainDistance)
            {
                Destroy(GameObject.Find("Enemy_Bullet(Clone)"));
            }

            if (Enemy_Bullet.position.z > constrainDistance)
            {
                Destroy(GameObject.Find("Enemy_Bullet(Clone)"));
            }
            if (Enemy_Bullet.position.z < -constrainDistance)
            {
                Destroy(GameObject.Find("Enemy_Bullet(Clone)"));
            }
        }

    }

}