using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plankcounter : MonoBehaviour {

    public GameObject UIscripts;
    private player Player;
    public GameObject PlankCounter;

    // Use this for initialization
    void Start () {
        Player = UIscripts.GetComponent<player>();
    }
	
	// Update is called once per frame
	void Update () {
        PlankCounter.GetComponent<Text>().text = Player.plank.ToString()+"/3";

    }
}
