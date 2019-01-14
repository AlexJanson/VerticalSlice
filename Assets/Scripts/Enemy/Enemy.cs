using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    protected Transform Player;

    [SerializeField]
    private GameObject player;

    private Vector3 v_diff;
    private float atan2;

    protected int health;
    private int attackTimer;
    public int playerTesthealth = 3;
    
    private bool follow;
    private bool attack = true;


    protected float attackRange;
    protected float walkingDistance;
    protected float moveSpeed; //move speed: slow = 0.01f, normal = 0.05f, fast = 0.1f
    
    //Call every frame

    private void Awake()
    {
        //  player = GetComponent<>();
    }

   public abstract void Attack();

    public bool IsPlayerClose()
    {
        
        //Calculate distance between player
        float distance = Vector2.Distance(transform.position, Player.position);
        //Debug.Log(distance);
        //If the distance is smaller than the walkingDistance
        if (distance < walkingDistance && follow == true)
        {
           

            transform.position = Vector3.MoveTowards(transform.position, Player.position, moveSpeed);
        }
        if (distance < 1.5f)
        {
           
            follow = false;
        }
        if (distance > 2.0f)
        {          
            follow = true;
        }
        return Vector2.Distance(player.transform.position, gameObject.transform.position) < attackRange;
    }

    public bool CloseAttackPlayer()
    {

        float distance = Vector2.Distance(transform.position, Player.position);

        if (distance <= attackRange && attack == true)
        {
            playerTesthealth -= 1;
            Debug.Log(playerTesthealth);
            attack = false;
        }
        if(attack == false)
        {
            attackTimer++;
        }
        if(attackTimer == 100)
        {
            attack = true;
            attackTimer = 0;
        }
        return Vector2.Distance(player.transform.position, gameObject.transform.position) < attackRange;
    }
    
}
