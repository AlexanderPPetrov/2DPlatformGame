using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float moveSpeed = 10f;

    public static float health = 100;

    public GameObject destroyEffect;

    private GameObject destroyAnimation;


    // Move the egg in the opposite direction of the player if collision happens
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Debug.Log("Player collide ");
            var magnitude = 350;
            // calculate force vector
            var force = transform.position - col.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);
        }
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        Debug.Log("TakeDamage: " + damage);
        if (health <= 0)
        {
            DestroyEgg();
        }
    }

    void DestroyEgg()
    {
        // Remove the egg
        Destroy(gameObject);

        // Create destroy effect instance
        GameObject destroyAnimation = Instantiate(destroyEffect, transform.position, Quaternion.identity);

        // Remove animation after 3 sec
        Destroy(destroyAnimation, 3);
    }



}


