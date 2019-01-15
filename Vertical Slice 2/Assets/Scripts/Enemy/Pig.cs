using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Enemy {

    public override void Attack()
    {
        if (!CanAttack()) return;

        //TODO DO Tackle


    }

    void Update()
    {
        if (IsPlayerClose())
            Attack();
    }

    void FixedUpdate()
    {
        if (IsPlayerClose()) return;

        Move(player.transform.position);
    }

}
