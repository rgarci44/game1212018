using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour {

    private AudioSource pickupAudioSource;

    // Use this for initialization
    void Start () {
        pickupAudioSource = GameObject.Find("Waypoint_Right").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Collider otherCollider = collision.collider;
        GameObject otherObject = collision.gameObject;
        Transform otherTransform = collision.transform;
        Rigidbody otherRigidBody = collision.rigidbody;
 
        if (otherObject.tag == "Ammo")
        {
            pickupAudioSource.Play();
            if (FPS_Script.switchGun == false)
            {
                Camera_Script.regGunClip += 6;
                Camera_Script.ammo = Camera_Script.regGunClip;
                Destroy(GameObject.Find("Ammo_Pickup(Clone)"));
            }

            if (FPS_Script.switchGun == true)
            {
                Camera_Script.machGunClip += 100;
                Camera_Script.ammo = Camera_Script.machGunClip;
                Destroy(GameObject.Find("Ammo_Pickup(Clone)"));
            }
           
        }

        if (otherObject.tag == "MachGun")
        {
            pickupAudioSource.Play();
            FPS_Script.machGun = true;
            Camera_Script.machGunClip += 100;
            if (FPS_Script.switchGun == false)
            {
                FPS_Script.switchGun = true;
                Camera_Script.ammo = Camera_Script.machGunClip;
                Destroy(GameObject.Find("MachGun_Pickup"));
            }

        }
        if (otherObject.tag == "Health")
        {
            pickupAudioSource.Play();
            BulletCollision.health += 25;
            Destroy(GameObject.Find("Health_Pickup(Clone)"));
        }

    }
}
