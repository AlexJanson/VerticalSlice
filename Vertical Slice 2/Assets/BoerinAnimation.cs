using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BoerinAnimation : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        FindObjectOfType<WaveManager>().startNewWaveAction += PointAnimation;
    }

    private void PointAnimation(int wave)
    {
        anim.Play("Point animation2");
        Debug.Log("Called");
    }
}
