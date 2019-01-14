using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Enemy {

    [SerializeField]
    private GameObject projectile;
    
    public override void Attack()
    {
        if (!CanAttack()) return;

        GameObject projectile = Instantiate(this.projectile, transform.position, this.projectile.transform.rotation);

        
    }

    private void FixedUpdate()
    {
        if (IsPlayerClose()) return;
    
        Move(player.transform.position);
    }

    // Update is called once per frame
    void Update () {
		if (IsPlayerClose())
        {
            Attack();
        }
	}
}
