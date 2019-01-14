using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    [HideInInspector]
    public Vector2 target;
    public float speed = 6.0f;

    private void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        if(Vector2.Distance(target, transform.position) < 0.05f) {
            Destroy(this.gameObject);
        }
    }
}
