using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int mDamage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.gameObject.CompareTag("Player"))
        {
            Health health = hit.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(mDamage);
                HealthBar hBar = hit.GetComponent<HealthBar>();
                if (hBar)
                {
                    hBar.UpdateHealth();
                }

                Destroy(gameObject);
            }
        }

        if (hit.gameObject.CompareTag("Enemy"))
        {
            Health health = hit.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(mDamage);
                HealthBar_Enemy hBar = hit.GetComponentInChildren<HealthBar_Enemy>();
                if (hBar)
                {
                    hBar.UpdateHealth();
                }

                Destroy(gameObject);
            }
        }
    }


}