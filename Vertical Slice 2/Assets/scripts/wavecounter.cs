using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavecounter : MonoBehaviour {

    public GameObject UIscripts;
    public GameObject Wavecounter;

    private WaveManager waveManager;


    // Use this for initialization
    void Start () {
        waveManager = FindObjectOfType<WaveManager>();

        waveManager.startNewWaveAction += UpdateWaveCounter;
    }
	
	// Update is called once per frame
	void Update () {


    }

    private void UpdateWaveCounter(int wave)
    {
        Wavecounter.GetComponent<Text>().text = "Waves : " + wave.ToString();
    }
}
