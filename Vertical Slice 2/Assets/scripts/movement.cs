﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    private Rigidbody2D player;
    public float speed = 1f;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        player.AddRelativeForce(Vector2.up * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        player.AddRelativeForce(Vector2.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        if (h == 0f && v == 0f)
        {
            player.velocity = Vector2.zero;
        }
        //else if (h == 0 && v != 0)
        //{
        //    player.velocity = new Vector2(0, player.velocity.y);
        //    player.AddRelativeForce((Vector2.up * speed) * v / 2);
        //}
        //else if (h != 0 && v == 0)
        //{
        //    player.AddRelativeForce((Vector2.right * speed) * h / 2);
        //    player.velocity = new Vector2(player.velocity.x, 0);
        //}


            //if (player.velocity.x != 0f)
            //{
            //    player.velocity = new Vector2(player.velocity.x, player.velocity.x);
            //}
    }
}
// is er input op een as die voorheen geen input had?
// zo ja, zet dan de velocity van deze nieuwe input (as) naar de velocity die er al wel was

// is er al kracht op de x of y waarde v/d velocity?
// zo ja, pas deze dan toe op de andere as-wanneer deze 0 is
// zo nee, dan kun je gewoon de force toevoegen
//