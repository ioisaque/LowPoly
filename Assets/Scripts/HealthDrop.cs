using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    public int ammountOfHealth;

    void OnCollisionEnter(Collision collision)
    {
        //If bullet collides with "Player" tag
        if (collision.transform.tag == "Player")
        {
            //Add Ammo to Player
            collision.gameObject.GetComponentInChildren
                <PlayerHealth>().health += ammountOfHealth;

            //Destroy bullet object
            Destroy(gameObject);
        }
    }
}
