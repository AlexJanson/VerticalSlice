using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public float health;

    public event Action<float, GameObject> playerDamageAction;
    public event Action playerDeathAction;

    void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
        playerDamageAction += Knockback;
        playerDeathAction += Death;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool knockback;

    public void Damage(float damage, GameObject enemy)
    {
        if (knockback) return;

        health -= damage;

        if (playerDamageAction != null)
        playerDamageAction(damage, enemy);

        if (health <= 0)
        {
            health = 0;

            if (playerDeathAction != null)
                playerDeathAction();

            return;
        }
    }

    public void Heal(float _health)
    {

        health += _health;


        if (health > 100)
            health = 100;
    }

    [SerializeField]
    private float knockbackSpeed;

    private Vector2[] point = new Vector2[3];

    private float startTime;

    float count;

    private void Knockback(float damage, GameObject enemy)
    {
        if (enemy == null || knockback) return;

        Vector2 knockbackLoc = gameObject.transform.position + (gameObject.transform.position - enemy.transform.position);

        count = 0;

        point[0] = gameObject.transform.position;

        point[2] = knockbackLoc;

        point[1] = point[0] + (point[2] - point[0]) / 2 + Vector2.up * 6.0f;

        // Keep a note of the time the movement started.
        startTime = Time.time;

        knockback = true;
    }

    void FixedUpdate()
    {
        if (!knockback) return;

        if (count < 0.9f)
        {
            count += 1.0f * Time.deltaTime * knockbackSpeed;

            Vector2 m1 = Vector2.Lerp(point[0], point[1], count);
            Vector2 m2 = Vector2.Lerp(point[1], point[2], count);
            transform.position = Vector2.Lerp(m1, m2, count);
        } else
        {
            knockback = false;

        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
