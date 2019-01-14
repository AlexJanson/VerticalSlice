using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bulletPrefab;
    public float fireDelay = 2f;

    float nextFire = 0;
    Vector3 direction;

    private void Update()
    {
        direction = Input.mousePosition;
        direction.z = 0;
        direction = Camera.main.ScreenToWorldPoint(direction);
        direction = direction - transform.position;
        if(Input.GetMouseButtonDown(0) && Time.time > nextFire) {
            nextFire = Time.time + fireDelay;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
