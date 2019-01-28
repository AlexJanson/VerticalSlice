using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{

    [HideInInspector]
    public int chickens;

    private SpriteRenderer _sprite;
    private Rigidbody2D _body;
    public float MoveSpeed;

    private void Awake()
    {
        chickens = 0;
        _body = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var horiz = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        var newSpeed = MoveSpeed - (MoveSpeed / 10 * chickens);

        _body.velocity = new Vector2(horiz, vert) * newSpeed;
    }
}