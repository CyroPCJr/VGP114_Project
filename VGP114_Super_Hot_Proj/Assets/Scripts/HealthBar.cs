using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("References")]
    public Image ImgHealthBar;
    public Text TxtHealth;
    private Health health;
    void Start()
    {
        //setHealth(Max);
        health = GetComponentInParent<Health>();
    }

    public void UpdateHealth()
    {
        float healthPercentage = ((float)health.CurrentHealth / (float)health.MaxHealth) * 100.0f;
        TxtHealth.text = $"{healthPercentage} %";
        ImgHealthBar.fillAmount = (healthPercentage * 0.01f); // max value is 1 and min 0
    }

}
