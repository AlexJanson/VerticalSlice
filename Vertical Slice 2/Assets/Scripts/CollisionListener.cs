using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionListener : MonoBehaviour
{


         // then assign this on the Inspector
     
    public event Action ammoCollected;

    private PlayerShoot playershoot;


    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.tag == "ammo")
            {
                Destroy(collision.gameObject);
                ammoCollected();           
            }            
    }
}
