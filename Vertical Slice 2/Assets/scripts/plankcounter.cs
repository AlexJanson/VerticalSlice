using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plankcounter : MonoBehaviour {

    public GameObject UIscripts;
    private player Player;
    public GameObject PlankCounter;
    int wave;

    // Use this for initialization
    void Start () {
        Player = UIscripts.GetComponent<player>();
        FindObjectOfType<WaveManager>().startNewWaveAction += UpdatePlanks;
    }
	
	// Update is called once per frame
	void Update () {
        PlankCounter.GetComponent<Text>().text = wave+"/3";
    }
    private void UpdatePlanks(int _wave)
    {
        wave = _wave;
    }
}
