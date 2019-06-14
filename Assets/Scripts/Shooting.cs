using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //This is the prefab that is created when the weapon is fired
    //Drag the prefab in the unity editor to set it
    public GameObject bullet;

    //Check if the player is the one firing the weapon
    //This is used to determine if shots should use a click
    //Or automatically fire
    private bool isPlayerWeapon = false;

    //Cooldown time between shots
    public float coolDownTime = .25f;

    //After a shot is fired, set this to coolDownTime
    //Then every frame, subtract Time.deltaTime
    //A shot can only be fired when this is back to 0
    private float coolDownTimeRemaining = 0f;

    private Transform objectPos;


    private void Start()
    {
        objectPos = GetComponent<Transform>();

        if (gameObject.tag == "Player")
        {
            isPlayerWeapon = true;
        }

    }

    private void Update()
    {
        //Check if the weapon cool down time is up
        //If so, allow an attack, else subtract Time.deltaTime from coolDownTimeRemaining

        //The weapon is either used by the player or an Enemy
        if (isPlayerWeapon)
        {
            //Check if either of the fire buttons are pressed, and if so, use the player's current weapon
            if (Input.GetMouseButtonDown(0))
            {
                if (coolDownTimeRemaining <= 0)
                {
                    Instantiate(bullet, objectPos.position, Quaternion.identity);
                    coolDownTimeRemaining = coolDownTime;
                }
                else
                {
                    coolDownTimeRemaining -= Time.deltaTime;
                }
            }
        }
        //Enemies will always shoot if they can
        else
        {
            if (coolDownTimeRemaining <= 0)
            {
                Instantiate(bullet, objectPos.position, Quaternion.identity);
                coolDownTimeRemaining = coolDownTime;
            }
            else
            {
                coolDownTimeRemaining -= Time.deltaTime;
            }

        }
    }



}
