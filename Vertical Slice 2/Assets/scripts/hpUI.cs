using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUI : MonoBehaviour {

    public Image HeartFilled;
<<<<<<< HEAD
    public GameObject healthPercentage;
    private PlayerDeath playerDeath;
=======
    //public GameObject healthPercentage;
    private player Player;
    public GameObject UIscripts;
>>>>>>> ui
    private float begin;
    static float t = 0.0f;

    private bool death;

    // Use this for initialization
    void Start () {
        playerDeath = FindObjectOfType<PlayerDeath>();

        playerDeath.playerDeathAction += Death;

        HeartFilled.type = Image.Type.Filled;
        HeartFilled.fillMethod = Image.FillMethod.Vertical;
        begin = playerDeath.health;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (death && HeartFilled.fillAmount > 0)
        {
            death = true;
            HeartFilled.fillAmount = Mathf.Lerp((begin / 100.0f), (0 / 100.0f), t);
            t += 1.0f * Time.deltaTime;
            healthPercentage.GetComponent<Text>().text = "" + Mathf.Round(HeartFilled.fillAmount * 100f);
        }

        if (playerDeath == null) return;

<<<<<<< HEAD
        if(playerDeath.health != begin) {

            HeartFilled.fillAmount = Mathf.Lerp( (begin/100.0f), (playerDeath.health / 100.0f), t);
            t += 1.0f * Time.deltaTime;
            healthPercentage.GetComponent<Text>().text = "" + Mathf.Round(HeartFilled.fillAmount * 100f);
=======
            HeartFilled.fillAmount = Mathf.Lerp( (begin/100.0f), (Player.hp/100.0f), t);
            t += 0.5f * Time.deltaTime;
            //healthPercentage.GetComponent<Text>().text = Player.hp.ToString();
>>>>>>> ui
        }

        if (t > 1.0f) {
            begin = playerDeath.health;
            t = 0.0f;
        }
    }

    private void Death()
    {
        death = true;

    }
}
