using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoBar : MonoBehaviour {

    public Image AmmoFilled;
    public GameObject AmmoCounter;
    private player Player;
    public GameObject UIscripts;
    public Text UIallAmmo;

    private PlayerShoot playerUpdateClip;

    // Use this for initialization
    void Start () {
        playerUpdateClip = FindObjectOfType<PlayerShoot>();
        playerUpdateClip.playerShootAction += UpdateAmmo;
        playerUpdateClip.chickenAllAmmo += UpdateFullAmmo;
    }
	
	// Update is called once per frame
	void Update () {
        Player = UIscripts.GetComponent<player>();
        AmmoFilled.type = Image.Type.Filled;
        AmmoFilled.fillMethod = Image.FillMethod.Horizontal;
      
    }

    private void UpdateAmmo(int ammo)
    {
        AmmoFilled.fillAmount = ammo / 30f;
        AmmoCounter.GetComponent<Text>().text = ammo.ToString();
    }

    private void UpdateFullAmmo(int FullAmmo)
    {
        AmmoCounter.GetComponent<Text>().text = FullAmmo.ToString();
    }
}
