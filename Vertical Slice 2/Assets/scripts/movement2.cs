using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
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


        player.AddRelativeForce(Vector2.up * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        player.AddRelativeForce(Vector2.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));

        player.velocity = new Vector2(h * speed, v * speed);

        if (h == 0f && v == 0f)
        {
            player.velocity = Vector2.zero;
        }

    }
}
