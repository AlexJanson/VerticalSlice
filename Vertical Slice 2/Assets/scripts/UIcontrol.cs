using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrol : MonoBehaviour {

    public GameObject UIscripts;
    private player Player;
    // A = ammo H = hp
    private float A_m_MyVar = 0;
    private float A_myVar = 0;
    private float H_m_MyVar = 0;
    private float H_myVar = 0;

    public delegate void OnVariableChangeDelegate(float newVal);
    public static event OnVariableChangeDelegate OnVariableChange;

    void Start()
    {
        Player = UIscripts.GetComponent<player>();
        A_m_MyVar = Player.ammo;
        H_m_MyVar = Player.hp;
    }

    private void Update()
    {

        A_myVar = Player.ammo;
        H_myVar = Player.hp;
        if ( (A_myVar != A_m_MyVar || H_myVar != H_m_MyVar) && OnVariableChange != null)
        {
            A_m_MyVar = A_myVar;
            H_m_MyVar = H_myVar;
            OnVariableChange(0);
        }
    }


}
