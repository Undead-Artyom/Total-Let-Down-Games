using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lazyHealthBar : MonoBehaviour
{
    private float maxHP = 100, currHP, currHPSlow;
    public float damage = 100;
    public Image barFast, barSlow;
    public PlayerHealth playerHeath; 
    // Start is called before the first frame update

    void Start()
    {
        //currHP = playerHeath.maxHealth;
        //currHPSlow = playerHeath.maxHealth;
        currHP = maxHP;
        currHPSlow = maxHP;
    }

    // Update is called once per frame
    float t = 0;
    void Update()
    {
        //interpolating slowHP and currentHP inf unequal
        if (currHPSlow != currHP)
        {
            currHPSlow = Mathf.Lerp(currHPSlow, currHP, t);
            t += 0.5f * Time.deltaTime;
        }
        else
        {
            t = 0;
            //resetting interpolator
        }

        //Setting fill amount
        barFast.fillAmount = currHP / maxHP;
        barSlow.fillAmount = currHPSlow / maxHP;
    }

    public void loseHP()
    {
        currHP -= damage;
    }
}
