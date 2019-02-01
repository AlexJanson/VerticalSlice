using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUI : MonoBehaviour
{

    public Image HeartFilled;
    //public GameObject healthPercentage;
    private float begin;
    static float t = 0.0f;

    private PlayerDeath playerDeath;

    [SerializeField]
    private Text hp;

    private bool updateHealth;
    

    // Use this for initialization
    void Start()
    {
        HeartFilled.type = Image.Type.Filled;
        HeartFilled.fillMethod = Image.FillMethod.Vertical;

        playerDeath = FindObjectOfType<PlayerDeath>();

        begin = playerDeath.health;

        playerDeath.playerDamageAction += UpdateHealth;
    }

    void FixedUpdate()
    {
        if (!updateHealth) return;

        if (HeartFilled.fillAmount == playerDeath.health / 100.0f)
        {
            updateHealth = false;
            return;
        }

        HeartFilled.fillAmount = Mathf.Lerp((begin / 100.0f), (playerDeath.health / 100.0f), t);
        t += 0.5f * Time.deltaTime;
        hp.text = playerDeath.health.ToString();

        if (t > 1.0f)
        {
            begin = playerDeath.health;
            t = 0.0f;
        }
    }

    private void UpdateHealth(float damage, GameObject gameObject)
    {
        updateHealth = true;
    }
}