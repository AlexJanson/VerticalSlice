using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    private GameObject player;
    private int health;
    private float attackRange;
    protected float attackDelay;
    private bool isAttackOnCooldown;

    private void Awake()
    {
      //  player = GetComponent<>();
    }

    // Use this for initialization
    void Start()
    {
        isAttackOnCooldown = false;
    }

    public abstract void Attack();

    public bool IsPlayerClose()
    {
        return Vector2.Distance(player.transform.position, gameObject.transform.position) < attackRange;
    }

    private IEnumerator AttackCooldown()
    {
        if (!isAttackOnCooldown)
        {
            isAttackOnCooldown = true;
            yield return new WaitForSeconds(attackDelay);
            isAttackOnCooldown = false;
        }
    }

    protected bool CanAttack()
    {
        if (!isAttackOnCooldown)
        {
            AttackCooldown();
            return true;
        }

        return false;
    }
}
