using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoBar : MonoBehaviour {

    public Image AmmoFilled;
    public GameObject AmmoCounter;
    private player Player;
    public GameObject UIscripts;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Player = UIscripts.GetComponent<player>();
        AmmoFilled.type = Image.Type.Filled;
        AmmoFilled.fillMethod = Image.FillMethod.Horizontal;
        AmmoFilled.fillAmount = Player.ammo / 30f;
        AmmoCounter.GetComponent<Text>().text = Player.ammo.ToString();
    }
}
