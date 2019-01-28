using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour {

    [SerializeField]
    protected PlayerDeath player;

    public float maxHealth;
    protected float health;

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

    public event Action<float, float> enemyDamageAction;

    private List<Node> path;

    private GridManager gridManager;

    public abstract void Attack();

    private void SetState(EnemyState enemyState)
    {
        state = enemyState;

        //TODO EDIT ANIMATION STATE VARIABLE
    }

    private void Start()
    {
        //  animator = GetComponent<Animator>();

        health = maxHealth;
        player = FindObjectOfType<PlayerDeath>();

        state = EnemyState.IDLE;

        gridManager = FindObjectOfType<GridManager>();
    }

    protected void Move(Vector2 position)
    {
        state = EnemyState.MOVE;
        // transform.position = Vector2.MoveTowards(transform.position, position, moveSpeed * Time.deltaTime);

        path = AStarPath.FindPath(new Vector2(transform.position.x, transform.position.y), new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y), gridManager.map);

        if (path != null)
        {
            path.Reverse();

            StartCoroutine(FollowPath(path));
        }
    }

    IEnumerator FollowPath(List<Node> waypoints)
    {

        transform.position = waypoints[0].position;

        int targetWaypointIndex = 0;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex].position;

        while (new Vector2(transform.position.x, transform.position.y) != waypoints[waypoints.Count].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, moveSpeed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                if (targetWaypointIndex < waypoints.Count - 1)
                {
                    targetWaypointIndex++;
                    targetWaypoint = waypoints[targetWaypointIndex].position;
                }
            }
            yield return null;
        }

        Destroy(gameObject);
    }


    protected bool IsPlayerClose()
    {
        if (player != null)
        {
            bool isClose = Vector2.Distance(player.transform.position, gameObject.transform.position) < attackRange;

            if (isClose)
            {
                StopCoroutine(FollowPath(null));
            }

            return isClose;
        }

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

    public void Damage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;

            Destroy(gameObject);
        }

        if (enemyDamageAction != null)
            enemyDamageAction(health, damage);


    }

    public enum EnemyState
    {
        MOVE, ATTACK, IDLE, DEATH
    }
}
