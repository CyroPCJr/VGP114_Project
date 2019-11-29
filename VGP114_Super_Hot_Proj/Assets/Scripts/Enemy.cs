using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    private readonly float mMinDistance = 15.0f;
    private float mPlayerDistance = 0.0f;
    private Animator mAnimator;

#region Just for test
    public int hitCount = 3; //number of hits
    public float hitTime = 2.0f; //time in seconds between each hit
    float curTime = 0; //time in seconds since last hit
    public Rigidbody projectile;
    private float bulletImpulse = 20.0f;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitCount > 0) //if there are more hits left
        {
            curTime += Time.deltaTime; //add time
        }
        mPlayerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (player && (mPlayerDistance < mMinDistance))
        {
            LookAtPlayer();
            if (mPlayerDistance <= 14.0f)
            {
                if (curTime >= hitTime)
                {
                    Attack();
                }
            }
        }
        else
        {
            mAnimator.SetBool("isIdle", true);
        }
    }

    private void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2.0f);
    }

    private void Attack()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
                bullet.AddForce(transform.forward * bulletImpulse, ForceMode.Impulse);
                Destroy(bullet.gameObject, 2);
                //hit.collider.gameObject.GetComponent<>().health -= 5f;
                Debug.Log("Enemy_Attack: Hit");
                curTime = 0; //reset the time
                hitCount--; //subtract one from the hit count
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (player)
        {
            if (mPlayerDistance < mMinDistance)
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawLine(transform.position, player.transform.position);
        }

        Vector3 position = transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + 3.0f * transform.forward);
    }
}
