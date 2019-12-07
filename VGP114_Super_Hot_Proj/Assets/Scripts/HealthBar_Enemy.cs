using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Enemy : MonoBehaviour
{
    public Image ImgHealthBar;
    public int Min;
    public int Max;

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
        ImgHealthBar.fillAmount = (healthPercentage * 0.01f); // max value is 1 and min 0
    }
    //public void setHealth(int health)
    //{
    //    if(health != mCurrentValue)
    //    {
    //        if(Max - Min == 0)
    //        {
    //            mCurrentValue = 0;
    //            mCurrentPercent = 0;
    //        }
    //        else
    //        {
    //            mCurrentValue = health;
    //            mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
    //        }

    //        ImgHealthBar.fillAmount = mCurrentPercent;
    //    }
    //}

    //public float CurrentPercent
    //{
    //    get { return mCurrentPercent; }
    //}

    //public int CurrentValue
    //{
    //    get { return mCurrentValue; }
    //}

    //// Start is called before the first frame update
    //void Start()
    //{
    //    setHealth(Max);
    //}


}
