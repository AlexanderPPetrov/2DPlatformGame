using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    Vector3 localScale;
    public Egg egg;

    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = 20 * (egg.getHealth() / 100);
        transform.localScale = localScale;
    }
}
