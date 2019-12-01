using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour, ICharacterAction
{

    public Transform player;
    private readonly float mMinDistance = 15.0f;
    private float mPlayerDistance = 0.0f;
    private Animator mAnimator;
    private float health = 5.0f;
    private bool _isFind = false;
    private NavMeshAgent _agent;

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
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        mPlayerDistance = Vector3.Distance(player.transform.position, transform.position);

        if (hitCount > 0) //if there are more hits left
        {
            curTime += Time.deltaTime; //add time
        }
        
        if (player && (mPlayerDistance < mMinDistance))
        {
            _agent.isStopped = true;
            LookAtPlayer();
            Attack();
            mAnimator.SetBool("isRunning", false);
        }
        else
        {
            mAnimator.SetBool("isRunning", true);
            _agent.isStopped = false;
            mAnimator.SetBool("isIdle", true);
        }

        if(!_isFind)
        {
            Debug.Log("Where is player?");
        }
        else
        {
            
            Debug.Log("There you are!");
        }

        _agent.SetDestination(player.position);
    }

    private void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2.0f);
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

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0.0f)
        {
            Destroy(this);
        }
    }

    public void Attack()
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
    
}
