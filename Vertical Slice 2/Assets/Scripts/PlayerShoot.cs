﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

<<<<<<< HEAD
    [SerializeField]
    private GameObject AmmoBag;

    [SerializeField]
    private Transform transformAmmoBag;
=======
>>>>>>> origin/player-shooting

    public int MaxAmmo = 90;
    private int ammo = 30;
    public int currentAmmo = 30;

    public GameObject bulletPrefab;
    public float fireDelay = 2f;

    float nextFire = 0;
    Vector3 direction;

    private void Awake()
    {
        var ammoCollisionSystem = GetComponent<CollisionListener>();
        ammoCollisionSystem.ammoCollected += getAmmo;
    }

    private void Update()
    {
        direction = Input.mousePosition;
        direction.z = 0;
        direction = Camera.main.ScreenToWorldPoint(direction);
        direction = direction - transform.position;
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && currentAmmo > 0) {

            currentAmmo--;
            
                 
            nextFire = Time.time + fireDelay;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        else if (Input.GetMouseButtonDown(0) && Time.time > nextFire && currentAmmo == 0)
        {
            Debug.Log("Your gun is empty RELOAD!");
        }

        Reload();

    }

    private void getAmmo()
    {
                MaxAmmo += 15;                            
    }

<<<<<<< HEAD
            if (distance < 1.0f)
            {
                Destroy(AmmoBag);
                transformAmmoBag = null;
                MaxAmmo += 15;
            }
        }
=======
    private void Reload()
    {
>>>>>>> origin/player-shooting
        if (Input.GetKeyDown("r"))
        {
            if (currentAmmo < ammo && MaxAmmo > 0)
            {
<<<<<<< HEAD
                // zorg ervoor dat max ammo niet in de min gaat

                Debug.Log("reload");
                
=======

                Debug.Log("reload");


>>>>>>> origin/player-shooting
                if (MaxAmmo - (ammo - currentAmmo) < 0)
                {
                    int missingBullets = ((ammo - currentAmmo) - MaxAmmo);
                    currentAmmo = ammo;
                    currentAmmo -= missingBullets;
                    MaxAmmo = 0;
                }
                else
                {
                    MaxAmmo -= (ammo - currentAmmo);
                    currentAmmo = ammo;
                }


            }
            else if (currentAmmo == ammo)
            {
                Debug.Log("ammo full");
            }
            else if (MaxAmmo <= 0)
            {
                Debug.Log("no ammo");
            }
        }
    }
}
