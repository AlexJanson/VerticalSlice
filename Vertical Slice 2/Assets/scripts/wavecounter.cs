using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavecounter : MonoBehaviour {

    public GameObject UIscripts;
    private player Player;
    public GameObject Wavecounter;

    // Use this for initialization
    void Start () {
        Player = UIscripts.GetComponent<player>();
    }
	
	// Update is called once per frame
	void Update () {
        Wavecounter.GetComponent<Text>().text = "Waves : "+Player.waves.ToString();

    }
}
