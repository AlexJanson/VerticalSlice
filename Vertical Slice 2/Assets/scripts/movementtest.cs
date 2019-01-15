using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementtest : MonoBehaviour
{

    private Rigidbody2D player;
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h == 0f && v == 0f)
        {
            player.velocity = Vector2.zero;
        }
    }
}