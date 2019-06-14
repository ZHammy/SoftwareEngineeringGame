using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //How fast the projectile should move
    public float speed;
    //The direction the projectile will go
    private Vector2 direction;

    //Both enemies and players can shoot so need to differentiate to avoid friendly fire
    //This is used so that enemies' shots do not hurt each other
    public bool isPlayerShot = false;

    //How much damage the shot should cause when it hits a hostile object
    public int damage = 1;



    private void Start()
    {
        //if the bullet is a player shot, aim the shot at the current mouse location

        if (isPlayerShot)
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //if the bullet is from an enemy, aim the shot at the player
        else
        {
            direction = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, speed * Time.deltaTime);
        }   

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, direction) == 0)
        {
            Destroy(gameObject);
        }
    }


}
