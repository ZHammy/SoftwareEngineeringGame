using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public GameObject enemy;

    private Vector2 mouseTarget;

    private void Start()
    {
        mouseTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mouseTarget, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, mouseTarget) == 0)
        {
            Destroy(gameObject);
        }
    }


}
