using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public float timeToDestroy = 5f;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
