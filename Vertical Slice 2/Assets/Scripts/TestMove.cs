using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
	{
		private SpriteRenderer _sprite;
		private Rigidbody2D _body;
		public float MoveSpeed;

		private void Awake()
		{
			_body = GetComponent<Rigidbody2D>();
			_sprite = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			var horiz = Input.GetAxis("Horizontal");
			var vert = Input.GetAxis("Vertical");

			_body.velocity = new Vector2(horiz, vert) * MoveSpeed;
		}
	}