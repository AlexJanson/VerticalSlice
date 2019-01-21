using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    protected PlayerDeath player;

    [SerializeField]
    protected int health;

    [SerializeField]
    private float attackCooldownInSeconds;

    private bool isAttackOnCooldown;

    [SerializeField]
    protected float attackRange;
    protected float walkingDistance;

    [SerializeField]
    protected float moveSpeed;

    protected EnemyState state;

    private Animator animator;

    [SerializeField]
    protected float baseDamage;

    public abstract void Attack();

    private void SetState(EnemyState enemyState)
    {
        state = enemyState;

        //TODO EDIT ANIMATION STATE VARIABLE
    }

    private void Start()
    {
      //  animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerDeath>();

        state = EnemyState.IDLE;
    }

    protected void Move(Vector2 position)
    {
        state = EnemyState.MOVE;
        //transform.position = Vector2.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);
    }

    protected bool IsPlayerClose()
    {
        if (player != null)
            return Vector2.Distance(player.transform.position, gameObject.transform.position) < attackRange;

        return false;
    }
    
    protected bool CanAttack()
    {
        if (!isAttackOnCooldown)
        {
            StartCoroutine(AttackCooldown());

            // We gaan ervan uit dat wanneer de enemy kan attacken dat hij dat ook gaat doen,
            // zorg er daarom voor dat je eerst checked of de enemy dichtbij genoeg is en daarna pas checked of hij kan attacken.

            state = EnemyState.ATTACK;

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

public enum EnemyState
{
    MOVE, ATTACK, IDLE, DEATH
}
