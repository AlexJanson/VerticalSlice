using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    [SerializeField]
    private readonly float lifeTimeInSeconds;

    protected Vector3 destination;

    private Vector3 startPos;

    [SerializeField]
    private readonly float speed;

    private float startTime;

    private float journeyLength;

    void Start()
    {

        Destroy(gameObject, lifeTimeInSeconds);

        startPos = gameObject.transform.position;

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startPos, destination);
    }

    void Update()
    {
        if (Vector3.Distance(startPos, gameObject.transform.position) >= journeyLength && destination != Vector3.zero)
        {
            Hit();
        }
    }

    void FixedUpdate()
    {

        float distCovered = (Time.time - startTime) * speed;

        float fracJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startPos, destination, fracJourney);

    }

    public abstract void Hit();
}
