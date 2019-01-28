using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Enemy {

    public override void Attack()
    {
        if (!CanAttack()) return;
        if (player == null) return;


    }

    void Update()
    {
        if (IsPlayerClose())
            Attack();
    }

    void FixedUpdate()
    {
        if (IsPlayerClose()) return;
        if (player != null)
            Move(player.transform.position);
    }
}
