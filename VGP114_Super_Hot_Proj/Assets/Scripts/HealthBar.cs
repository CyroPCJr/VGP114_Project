using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("References")]
    public Image ImgHealthBar;
    public Text TxtHealth;
    private int Min = 0;
    private int Max = 50;

    private int mCurrentValue;
    private float mCurrentPercent;
    private Health health;
    void Start()
    {
        //setHealth(Max);
        health = GetComponentInParent<Health>();
    }

    public void UpdateHealth()
    {
        float healthPercentage = ((float)health.CurrentHealth / (float)health.MaxHealth) * 100.0f;
        Debug.Log($"PERCENTAGE {healthPercentage}");
        TxtHealth.text = $"{healthPercentage} %";
        ImgHealthBar.fillAmount = (healthPercentage * 0.01f); // max value is 1 and min 0
    }

    public void setHealth(int health)
    {
        if (health != mCurrentValue)
        {
            if (Max - Min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = health;
                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            }

            TxtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent * 100));
            ImgHealthBar.fillAmount = mCurrentPercent;
        }
    }

    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public int CurrentValue
    {
        get { return mCurrentValue; }
    }

    // Start is called before the first frame update


}
