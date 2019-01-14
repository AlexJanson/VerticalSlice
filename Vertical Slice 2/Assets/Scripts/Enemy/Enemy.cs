using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    protected GameObject player;

    [SerializeField]
    protected int health;

    [SerializeField]
    private float attackCooldownInSeconds;

    private bool isAttackOnCooldown;

    protected float attackRange;
    protected float walkingDistance;
    protected float moveSpeed; //move speed: slow = 0.01f, normal = 0.05f, fast = 0.1f

    public abstract void Attack();

    private void Start()
    {
      //  player = FindObjectOfType<>();
    }

    protected void Move(Vector2 position)
    {
        transform.position = Vector2.MoveTowards(transform.position, position, moveSpeed);
    }

    protected bool IsPlayerClose()
    {
        return Vector2.Distance(player.transform.position, gameObject.transform.position) < attackRange;
    }
    
    protected bool CanAttack()
    {
        if (!isAttackOnCooldown)
        {
            StartCoroutine(AttackCooldown());
            return true;
        }

        return false;
    }

    private IEnumerator AttackCooldown()
    {
        isAttackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldownInSeconds);
        isAttackOnCooldown = false;
    }
    
}
