using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUI : MonoBehaviour {

    public Image HeartFilled;
    public GameObject healthPercentage;
    private player Player;
    public GameObject UIscripts;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Player = UIscripts.GetComponent<player>();
        HeartFilled.type = Image.Type.Filled;
        HeartFilled.fillMethod = Image.FillMethod.Vertical;
        HeartFilled.fillAmount = Player.hp / 100f;
        healthPercentage.GetComponent<Text>().text = Player.hp.ToString();
    }
}
