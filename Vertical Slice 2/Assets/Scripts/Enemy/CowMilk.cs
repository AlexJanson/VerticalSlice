using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMilk : MonoBehaviour
{
    [SerializeField]
    private float lifeTimeInSeconds;

    [SerializeField]
    private float speed;

    [SerializeField]
    protected Vector2 destination;

    private Vector2[] point = new Vector2[3];

    private float startTime;

    private float journeyLength;

    float count = 0;

    void Start()
    {

        point[0] = gameObject.transform.position;

        point[2] = destination;

        point[1] = point[0] + (point[2] - point[0]) / 2 + Vector2.up * 6.0f;

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector2.Distance(point[0], point[2]);

        Destroy(gameObject, lifeTimeInSeconds);
    }

    void Update()
    {

        if (Vector2.Distance(point[0], gameObject.transform.position) >= journeyLength)
        {
            Hit();
        }
    }

    void FixedUpdate()
    {
        if (count < 1.0f) {
            count += 1.0f * Time.deltaTime * speed;

            Vector2 m1 = Vector2.Lerp(point[0], point[1], count);
            Vector2 m2 = Vector2.Lerp(point[1], point[2], count);
            gameObject.transform.position = Vector2.Lerp(m1, m2, count);
        }
    }

    private void Hit()
    {
       Destroy(gameObject);
    }
}
