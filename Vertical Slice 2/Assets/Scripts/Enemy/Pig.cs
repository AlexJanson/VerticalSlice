using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Enemy
{

    private void Start()
    {
        moveSpeed = 0.05f;
        walkingDistance = 10.0f;
        attackRange = 1.5f;
        health = 250;
    }
    public override void Attack()
    {
         
    }

    void Update()
    {
        IsPlayerClose();
        CloseAttackPlayer();
    }

  

}
