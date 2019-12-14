using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Enemy : MonoBehaviour
{   
    [SerializeField]
    private Image mImgHealthBar;
    private Health health;

    void Start()
    {
        health = GetComponentInParent<Health>();
    }

    public void UpdateHealth()
    {
        float healthPercentage = ((float)health.CurrentHealth / (float)health.MaxHealth) * 100.0f;
        mImgHealthBar.fillAmount = (healthPercentage * 0.01f); // max value is 1 and min 0
    }
   
}