using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Enemy {

    public override void Attack()
    {
        if (!CanAttack()) return;

        GameObject projectile = null;

        
    }
	
	// Update is called once per frame
	void Update () {
		if (IsPlayerClose())
        {
            Attack();
        }
	}
}
