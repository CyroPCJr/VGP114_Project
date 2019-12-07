using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour, ICharacterAction
{
    public AudioSource gunFire;
    public AudioSource gunShell;
    public AudioSource footStep;
    private bool footSoundPlay = false;
    private float count = 0.0f;

    public GameObject myCamera;
    private Animation cameraAnimation;


    private Animation mAnimation;
    public GameObject HandGun;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private readonly float mSpeed = 5.0f;
    private float gravity = -9.81f;
    private Rigidbody rb;

    public HealthBar healthBar;
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    int health = 50;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Vector3 tempVect = new Vector3(h, 0, v);
        //tempVect = tempVect.normalized * mSpeed * Time.deltaTime;
        //rb.MovePosition(transform.position + tempVect);


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 vForward = transform.forward;
        vForward.y = 0.0f;
        vForward.Normalize();
        Vector3 move = transform.right * h + vForward * v;
        controller.Move(move * mSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // play sound when move
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            cameraAnimation = myCamera.GetComponent<Animation>();

            float countTime = Time.deltaTime;
            count += countTime;
            if (countTime < 0.05f && footSoundPlay == false)
            {
                footStep.Play();
                cameraAnimation.Play("Camera");
                footSoundPlay = true;
            }
            if (count > 0.5f)
            {
                footSoundPlay = false;
                count = 0.0f;
            }
            
        }

        //play shooting
        if (Input.GetMouseButtonDown(0))
        {
            mAnimation = HandGun.GetComponent<Animation>();
            mAnimation.Play("GunRecoil");
            gunFire.Play();
            gunShell.Play();
            // create the bullet fromo the prefab
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 56.0f;

            // Destroy the bullet after 6s
            Destroy(bullet, 6);
        }
        
    }

    private void OnDrawGizmos()
    {
        Vector3 position = bulletSpawn.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + 50.0f * transform.forward);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        healthBar.setHealth(health);
        if (health <= 0.0f)
        {
            Debug.Log("Game Over!");
        }
    }

    public void Attack()
    {
        //throw new System.NotImplementedException();
    }
}