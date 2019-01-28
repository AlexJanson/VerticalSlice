using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdater : MonoBehaviour {

    public GameObject AmmoCounter;
    private player Player;
    public GameObject UIscripts;

    private void Start()
    {
        UIcontrol.OnVariableChange += VariableChangeHandler;
        Player = UIscripts.GetComponent<player>();
    }

    private void VariableChangeHandler(float newVal)
    {
        //doe iets
        //Debug.Log("Waardeverandering player. Healthcounter aanpassen.");
        AmmoCounter.GetComponent<Text>().text = Player.hp.ToString();
    }
}
