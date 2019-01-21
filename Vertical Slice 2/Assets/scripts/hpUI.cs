using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUI : MonoBehaviour {

    public Image HeartFilled;
    public GameObject healthPercentage;
    private PlayerDeath playerDeath;
    private float begin;
    static float t = 0.0f;

    // Use this for initialization
    void Start () {
        playerDeath = FindObjectOfType<PlayerDeath>();
        HeartFilled.type = Image.Type.Filled;
        HeartFilled.fillMethod = Image.FillMethod.Vertical;
        begin = playerDeath.health;
	}
	
	// Update is called once per frame
	void Update () {

        if(playerDeath.health != begin) {

            HeartFilled.fillAmount = Mathf.Lerp( (begin/100.0f), (playerDeath.health / 100.0f), t);
            t += 1.0f * Time.deltaTime;
            healthPercentage.GetComponent<Text>().text = "" + Mathf.Round(HeartFilled.fillAmount * 100f);
        }

        if (t > 1.0f) {
            begin = playerDeath.health;
            t = 0.0f;
        }
    }
}
