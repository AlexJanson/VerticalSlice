using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUI : MonoBehaviour {

    public Image HeartFilled;
    public GameObject healthPercentage;
    private player Player;
    public GameObject UIscripts;
    private float begin;
    static float t = 0.0f;

    // Use this for initialization
    void Start () {
        HeartFilled.type = Image.Type.Filled;
        HeartFilled.fillMethod = Image.FillMethod.Vertical;
        Player = UIscripts.GetComponent<player>();
        begin = Player.hp;
	}
	
	// Update is called once per frame
	void Update () {
        Player = UIscripts.GetComponent<player>();

        if(Player.hp != begin) {

            HeartFilled.fillAmount = Mathf.Lerp( (begin/100.0f), (Player.hp/100.0f), t);
            t += 0.5f * Time.deltaTime;
            healthPercentage.GetComponent<Text>().text = Player.hp.ToString();
        }

        if (t > 1.0f) {
            begin = Player.hp;
            t = 0.0f;
        }
    }
}
