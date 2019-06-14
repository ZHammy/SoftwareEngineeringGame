using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{

    //Default health to 1, but can change in unity
    public int maxHP = 1;

    //The start function will automatically set curHP to maxHP if this is left to -1
    //The start function will also automatically set this to maxHP if it is set greater than maxHP
    public int curHP = -1;

    //When the target runs out of health, this effect will be used
    //To set this, attatch an effect prefab in the Unity Editor
    public Transform deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Set the objects health to max unless a valid value (0<curHP<maxHP) was specified
        if (curHP == -1 || curHP > maxHP)
        {
            curHP = maxHP;
        }
    }

    //Inflict damage to the object
    public void Damage(int damageCount)
    {
        //apply the damage
        curHP -= damageCount;

        //If the health is now less than or equal to 0, kill the object
        if (curHP <= 0)
        {
            //If there is a dying effect, spawn it in
            if (deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            }
            //if the object is the player, restart the level
            //This is a place holder for now, implement a death sequence/ menu/ life system/ etc. later
            if (gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            Destroy(gameObject);
        }      
    }

    //Restore health to the object
    public void Heal(int healCount)
    {
        //Heal the current object
        curHP += healCount;
        //If the health went over the max value, reduce it.
        if (curHP > maxHP)
        {
            curHP = maxHP;
        }
    }

    //Change the max HP (Either up or down)
    public void ChangeMaxHP(int hpChange)
    {
        maxHP += hpChange;

        //if the maxHP is now less than 1, set it back to 1
        if (maxHP <= 0)
        {
            maxHP = 1;
        }

        //If the currentHP is now above the maxHP, adjust it down to new maxHP
        if (curHP > maxHP)
        {
            curHP = maxHP;
        }
    }
}
