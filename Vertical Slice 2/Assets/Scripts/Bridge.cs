using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField]
    private GameObject bridgeManager;

    [SerializeField]
    private List<Sprite> bridges;

    public GameObject UIscripts;

    private int plankAmount;

    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        repairBridge();
        plankAmount = UIscripts.GetComponent<player>().plank;
    }

    private void repairBridge()
    {
        if(plankAmount == 0)
        {
           sr.sprite = bridges[0];
        }
        else if (plankAmount == 1)
        {
            sr.sprite = bridges[1];
        }
        else if (plankAmount == 2)
        {
            sr.sprite = bridges[2];
        }
        else if (plankAmount == 3)
        {
            sr.sprite = bridges[3];
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
