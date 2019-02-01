using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float hp = 100f;
    public int ammo = 30;
    int plank;
    int waves;

    private void Start()
    {
        FindObjectOfType<WaveManager>().startNewWaveAction += PlankUI;
    }

    private void PlankUI(int _wave)
    {
        waves = _wave;
        plank = _wave;
    }
}
