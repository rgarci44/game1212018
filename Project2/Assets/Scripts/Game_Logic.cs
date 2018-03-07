using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Logic : MonoBehaviour
{
    public GameObject Ammo;
    public GameObject Health;
    public UnityEngine.UI.Text Ammo_Text1;
    public UnityEngine.UI.Text Ammo_Text2;
    public UnityEngine.UI.Text Health_Text1;
    public UnityEngine.UI.Text Health_Text2;
    public UnityEngine.UI.Text Weapon_Text1;
    public UnityEngine.UI.Text Weapon_Text2;
    public UnityEngine.UI.Text Win_Text;
    public UnityEngine.UI.Text Death_Text;


    // Use this for initialization
    void Start()
    {
        
        Ammo.SetActive(false);
        Health.SetActive(false);
        GameObject Health_Spawn = Instantiate(Health, new Vector3(Random.Range(-10, 10), Health.transform.position.y, Random.Range(-3, -10)), transform.rotation) as GameObject;
        Health_Spawn.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

        Ammo_Text1.text = ("Ammo: " + (Camera_Script.ammo.ToString()));
        Ammo_Text2.text = ("Ammo: " + (Camera_Script.ammo.ToString()));
        Health_Text1.text = ("Health: " + (BulletCollision.health.ToString()));
        Health_Text2.text = ("Health: " + (BulletCollision.health.ToString()));

        if (FPS_Script.switchGun == true)
        {
            Weapon_Text1.text = ("Machine Gun");
            Weapon_Text2.text = ("Machine Gun");
        }
        else
        {
            Weapon_Text1.text = ("Standard Gun");
            Weapon_Text2.text = ("Standard Gun");
        }


        if (BulletCollision.health <= 0)
        {
            Death_Text.text = "You Died!";
            FPS_Script.playable = false;
        }


       
        {
            
            if (Camera_Script.ammo <= 0 && ((GameObject.Find("Ammo_Pickup(Clone)")) == null))
            {
                
                GameObject Ammo_Spawn = Instantiate(Ammo, new Vector3(Ammo.transform.position.x, Ammo.transform.position.y, Ammo.transform.position.z), transform.rotation) as GameObject;
                Ammo_Spawn.SetActive(true);


            }

        }


       

    }

}




