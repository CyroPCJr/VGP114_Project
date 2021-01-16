using UnityEngine;
using UnityEngine.SceneManagement;

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
                HealthBar hBar = hit.GetComponentInChildren<HealthBar>();
                if (hBar)
                {
                    hBar.UpdateHealth();

                    if (health.isDead)
                    {
                        SceneManager.LoadScene("GameOver");
                    }

                    // Update here
                    //GameManager.Instance.CheckGameOver(hit);
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
                    Enemy enemy = hit.GetComponent<Enemy>();
                    enemy.GetHurt();
                    hBar.UpdateHealth();
                }

                Destroy(gameObject);
            }
        }

        if (hit.gameObject.CompareTag("Untagged"))
        {
            Destroy(gameObject);
            
        }
    }


}