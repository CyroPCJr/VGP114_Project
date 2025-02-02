﻿using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour //, ICharacterAction
{
    [SerializeField]
    private GameObject bulletPrefab;

    public Transform SpawnBullets;

    private CharacterControl mPlayer;

    private readonly float mBulletSpeed = 30.0f; // bullet speed

    private readonly float mRangeDistance = 15.0f;
    private float mPlayerDistance = 0.0f;
    private Animator mAnimator;

    private NavMeshAgent _agent;
    private Health mHealth;
    PlayerHud playerHud;
    public ParticleSystem blood;

    private bool mIsAlive = true;
    private void Awake()
    {
        mHealth = GetComponent<Health>();
        mPlayer = FindObjectOfType<CharacterControl>();
        playerHud = FindObjectOfType<PlayerHud>();
    }


    void Start()
    {
        mAnimator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        mPlayerDistance = Vector3.Distance(mPlayer.transform.position, transform.position);

        if (mPlayer && (mPlayerDistance <= mRangeDistance))
        {
            _agent.isStopped = true;
            LookAtPlayer();
            if (mIsAlive)
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
        if (mHealth.isDead && mIsAlive)
        {
            mAnimator.SetTrigger("isDead");
            playerHud.UpdateKills();
            Destroy(gameObject, 3.0f);
            mIsAlive = false;
            
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

    private float timerAttack = 0f;
    private float fireRate = 1f;
    public void Shooting()
    {
        if (Time.time > timerAttack)
        {
            timerAttack = Time.time + fireRate;
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                //if (hit.collider.gameObject.CompareTag("Player"))
                //{
                    GameObject bullet = Instantiate(bulletPrefab, SpawnBullets.position, SpawnBullets.rotation);
                    bullet.GetComponent<Rigidbody>().AddForce(transform.forward * mBulletSpeed, ForceMode.Impulse);
                    Destroy(bullet.gameObject, 10);
                //}
            }
        }
    }
    public void GetHurt()
    {
        blood.Play();
    }


}
