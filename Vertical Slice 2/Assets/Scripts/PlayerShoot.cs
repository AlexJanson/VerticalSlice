using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {


    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject BigAmmoBag;

    [SerializeField]
    private GameObject EButton;

    public event Action<int> playerShootAction;
    public event Action<int> chickenAllAmmo;
    public event Action<int> Fullammo;
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

            playerShootAction(currentAmmo);
                 
            nextFire = Time.time + fireDelay;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
        else if (Input.GetMouseButtonDown(0) && Time.time > nextFire && currentAmmo == 0)
        {
            Debug.Log("Your gun is empty RELOAD!");
        }

        if (MaxAmmo > 90)
        {
            MaxAmmo = 90;
        }
        Debug.Log(Vector2.Distance(BigAmmoBag.transform.position, gameObject.transform.position));

        if (Vector2.Distance(BigAmmoBag.transform.position, gameObject.transform.position) < 3) {

            EButton.SetActive(true);

            if (Input.GetKeyDown("e"))
            {
                
                    MaxAmmo += 30;
             }
        }
        else
        {
            EButton.SetActive(false);
        }
     
        Reload();

    }

    private void getAmmo()
    {
           MaxAmmo += 15;
    }

    private void Reload()
    {
        if (Input.GetKeyDown("r"))
        {
            if (currentAmmo < ammo && MaxAmmo > 0)
            {

                Debug.Log("reload");


                if (MaxAmmo - (ammo - currentAmmo) < 0)
                {
                    int missingBullets = ((ammo - currentAmmo) - MaxAmmo);
                    currentAmmo = ammo;
                    currentAmmo -= missingBullets;
                    MaxAmmo = 0;
                    chickenAllAmmo(MaxAmmo);
                    playerShootAction(currentAmmo);
                }
                else
                {
                    MaxAmmo -= (ammo - currentAmmo);
                    currentAmmo = ammo;
                    playerShootAction(currentAmmo);

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
