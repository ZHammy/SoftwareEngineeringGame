using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    HealthScript hp;

    public Text healthDisplay;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start()
    {
        hp= gameObject.GetComponent<HealthScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //healthDisplay.text = "HEALTH: " + hp.curHP;


        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Remove 1 HP from the enemy
            HealthScript hp = gameObject.GetComponent<HealthScript>();
            hp.Damage(1);

            //In the Enemy script, the player will also take damage from this collison
            Debug.Log("Player's health: " + hp.curHP);
        }

        if (collision.CompareTag("Projectile"))
        {
            //Get the script of the bullet that hit this enemey
            Projectile shot = collision.gameObject.GetComponent<Projectile>();

            //get the HP of the enemey
            HealthScript hp = gameObject.GetComponent<HealthScript>();

            //only apply damage if the projectile was from an enemey
            if (!shot.isPlayerShot)
            {
                //Apply damage to the enemy equal to the projectiles damge
                hp.Damage(shot.damage);
                Destroy(collision.gameObject);
            }

        }
    }

}
