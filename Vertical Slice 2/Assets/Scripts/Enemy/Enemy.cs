using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    private GameObject player;
    private int health;
    private float attackRange;

    private void Awake()
    {
      //  player = GetComponent<>();
    }

    public abstract void Attack();

    public bool IsPlayerClose()
    {
        return Vector2.Distance(player.transform.position, gameObject.transform.position) < attackRange;
    }
}
