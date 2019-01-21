using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoBar : MonoBehaviour {

    public Image AmmoFilled;
    public GameObject AmmoCounter;
    private player Player;
    public GameObject UIscripts;
    private float begin;
    static float t = 0.0f;

    // Use this for initialization
    void Start () {
        AmmoFilled.type = Image.Type.Filled;
        AmmoFilled.fillMethod = Image.FillMethod.Horizontal;
        Player = UIscripts.GetComponent<player>();
        begin = Player.ammo;
    }
	
	// Update is called once per frame
	void Update () {
        Player = UIscripts.GetComponent<player>();

        if (Player.ammo != begin)
        {

            AmmoFilled.fillAmount = Mathf.Lerp((begin / 30.0f), (Player.ammo / 30.0f), t);
            t += 0.5f * Time.deltaTime;
            AmmoCounter.GetComponent<Text>().text = Player.ammo.ToString();
        }

        if (t > 1.0f)
        {
            begin = Player.ammo;
            t = 0.0f;
        }
    }
}
