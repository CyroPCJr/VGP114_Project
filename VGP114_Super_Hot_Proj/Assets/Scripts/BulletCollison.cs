using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollison : MonoBehaviour
{
    public GameObject bullet;
    private readonly float mDamage = 10.0f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var damageable = collision.gameObject.GetComponent<ICharacterAction>();
            if (damageable != null)
            {
                damageable.TakeDamage(mDamage);
            }
            Debug.Log("Hit Enemy");
            Destroy(bullet);
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            var damageable = collision.gameObject.GetComponent<ICharacterAction>();
            if (damageable != null)
            {
                damageable.TakeDamage(mDamage);
            }
            Debug.Log("Hit Enemy");
            Destroy(bullet);
        }
    }
}
