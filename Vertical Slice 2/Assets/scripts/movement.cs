using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    private Rigidbody2D player;
    public float speed;
    private Animator animator;

	// Use this for initialization
	void Start () {
		player = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float isRight = 0;
        float isBack = 0;
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        
        if (pz.x > transform.position.x)
        {
            isRight = 1;
        }else if (pz.x < transform.position.x)
        {
            isRight = -1;
        }
        if (pz.y > transform.position.y+2)
        {
            isBack = 1;
        }else if (pz.y < transform.position.y-2)
        {
            isBack = -1;
        }
        animator.SetFloat("Vertical_Walk",v);
        animator.SetFloat("Horizontal_Walk",h);
        animator.SetFloat("Vertical_Idle", isBack);
        animator.SetFloat("Horizontal_Idle", isRight);

        player.velocity = new Vector2(h * speed * Time.deltaTime, player.velocity.y);
        player.velocity = new Vector2(player.velocity.x, v * speed *Time.deltaTime);



        //player.velocity = Vector2.up * Time.deltaTime * speed * Input.GetAxis("Vertical");

        //player.AddRelativeForce(Vector2.up * Time.deltaTime * speed * Input.GetAxis("Vertical"), ForceMode2D.Impulse);
        //player.AddRelativeForce(Vector2.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"), ForceMode2D.Impulse);
        if (h == 0f && v == 0f)
        {
            player.velocity = Vector2.zero;
        }
       
    }
}
