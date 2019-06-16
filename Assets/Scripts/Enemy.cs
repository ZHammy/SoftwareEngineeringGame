using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    public GameObject effect;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Remove 1 HP from the enemy
            HealthScript hp = gameObject.GetComponent<HealthScript>();
            hp.Damage(1);

            //In the Player script, the player will also take damage from this collison
        }

        if(collision.CompareTag("Projectile"))
        {
            //Get the script of the bullet that hit this enemey
            Projectile shot = collision.gameObject.GetComponent<Projectile>();

            //get the HP of the enemey
            HealthScript hp = gameObject.GetComponent<HealthScript>();

            //only apply damage if the projectile was from a player
            if (shot.isPlayerShot)
            {
                //Apply damage to the enemy equal to the projectiles damge
                hp.Damage(shot.damage);
                Destroy(collision.gameObject);
            }
            
        }
    }

}
