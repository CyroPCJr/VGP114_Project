using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour //, ICharacterAction
{
    [SerializeField]
    private GameObject mSpawnBullets;
    [SerializeField]
    private GameObject bulletPrefab;

    private CharacterControl mPlayer;

    private readonly float mBulletSpeed = 20.0f; // bullet speed

    private readonly float mRangeDistance = 15.0f;
    private float mPlayerDistance = 0.0f;
    private bool mIsOnRange = false;
    private Animator mAnimator;
    //    private float health = 5.0f;

    private NavMeshAgent _agent;

    #region Just for test
    public int hitCount = 3; //number of hits
    public float hitTime = 2.0f; //time in seconds between each hit
    float curTime = 0; //time in seconds since last hit
    #endregion
    private Health mHealth;
    PlayerHud playerHud;

    private void Awake()
    {
        mHealth = GetComponent<Health>();
        mPlayer = FindObjectOfType<CharacterControl>();
        playerHud = FindObjectOfType<PlayerHud>();
    }


    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        mIsOnRange = Vector3.Distance(mPlayer.transform.position, transform.position) < mRangeDistance;
        //mPlayerDistance = Vector3.Distance(mPlayer.transform.position, transform.position);

        if (hitCount > 0) //if there are more hits left
        {
            curTime += Time.time; //add time
        }

        if (mPlayer && (mIsOnRange))
        {
            _agent.isStopped = true;
            LookAtPlayer();
            if (curTime <= hitTime)
            {
                Shooting();
            }
            mAnimator.SetBool("isRunning", false);
        }
        else
        {
            mAnimator.SetBool("isRunning", true);
            _agent.isStopped = false;
            mAnimator.SetBool("isIdle", true);
        }

        _agent.SetDestination(mPlayer.transform.position);
        if (mHealth.isDead)
        {
            Destroy(gameObject);
            playerHud.UpdateKills();
        }
    }

    private void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(mPlayer.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (mPlayer)
        {
            if (mPlayerDistance < mRangeDistance)
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawLine(transform.position, mPlayer.transform.position);
        }

        Vector3 position = transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + 3.0f * transform.forward);
    }

    public void Shooting()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * mBulletSpeed, ForceMode.Impulse);
                Destroy(bullet.gameObject, 2);

                curTime = 0; //reset the time
                hitCount--; //subtract one from the hit count
            }
        }
    }

}
