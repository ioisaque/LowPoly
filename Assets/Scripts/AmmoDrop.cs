using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    public int ammountOfAmmo;

    void OnCollisionEnter(Collision collision)
    {
        //If bullet collides with "Player" tag
        if (collision.transform.tag == "Player")
        {
            //Add Ammo to Player
            collision.gameObject.GetComponentInChildren
                <AutomaticGunScriptLPFP>().totalAmmo += ammountOfAmmo;

            //Destroy bullet object
            Destroy(gameObject);
        }
    }
}
