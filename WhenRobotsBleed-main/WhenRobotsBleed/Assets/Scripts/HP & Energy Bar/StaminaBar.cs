using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    private float maxStamina = 100f, currentStamina, currentStaminaSlow;
    public float depletionRate = 1f; // How quickly the stamina decreases over time.
    public Image barFast, barSlow;
    public float regenRate = 2f; // How quickly the stamina regenerates when not moving.

    public float reductionAmount = 20f; // The amount of stamina to reduce when the button is clicked. Test

    void Start()
    {
        currentStamina = maxStamina;
        currentStaminaSlow = maxStamina;
        SetMaxStamina(maxStamina);
    }

    void Update()
    {
        // Regenerate stamina if not moving.
        if (Mathf.Approximately(Input.GetAxis("Horizontal"), 0f) && Mathf.Approximately(Input.GetAxis("Vertical"), 0f))
        {
            currentStamina += regenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }
        else
        {
            // Reduce stamina if moving.
            currentStamina -= depletionRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        }

        // Interpolate slow stamina value.
        if (currentStaminaSlow != currentStamina)
        {
            currentStaminaSlow = Mathf.Lerp(currentStaminaSlow, currentStamina, 0.5f * Time.deltaTime);
        }

        SetStamina(currentStamina, currentStaminaSlow);
    }


    public void SetMaxStamina(float stamina)
    {
        maxStamina = stamina;
        barFast.fillAmount = 1f;
        barSlow.fillAmount = 1f;
    }

    public void SetStamina(float currentStamina, float currentStaminaSlow)
    {
        barFast.fillAmount = currentStamina / maxStamina;
        barSlow.fillAmount = currentStaminaSlow / maxStamina;
    }

    public void ReduceStamina()
    {
        currentStamina -= reductionAmount;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        // Interpolate slow stamina value.
        if (currentStaminaSlow != currentStamina)
        {
            currentStaminaSlow = Mathf.Lerp(currentStaminaSlow, currentStamina, 0.5f * Time.deltaTime);
        }

        SetStamina(currentStamina, currentStaminaSlow);
    }

}

