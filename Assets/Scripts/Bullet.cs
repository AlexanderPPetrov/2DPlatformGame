using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {


        if(hitInfo.gameObject.name == "Player")
        {
            return;
        }

        Debug.Log(hitInfo.gameObject.name);

        Egg egg = hitInfo.GetComponent<Egg>();

        // If the object is actually an egg
        if(egg != null)
        {
            egg.TakeDamage(damage);
        }

        Debug.Log(hitInfo);

        // Destroy the bullet
        Destroy(gameObject);
    }
}
