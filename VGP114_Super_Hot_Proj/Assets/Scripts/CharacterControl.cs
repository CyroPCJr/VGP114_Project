using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour //, ICharacterAction
{
    [Header("References")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawn;
    [SerializeField]
    private LayerMask groundMask;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Transform groundCheck;

    private readonly float mSpeed = 15.0f; // player speed
    private readonly float groundDistance = 0.4f;
    private readonly float gravity = -9.81f;
    private readonly float mBulletSpeed = 55.0f; // bullet speed
    private bool isGrounded;
    Vector3 velocity;

    // private Rigidbody rb;
    //public HealthBar healthBar;
    //int health = 50;

    //void Start()
    //{
    //    // rb = GetComponent<Rigidbody>();
    //}

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

        Shooting();
        GameManager.Instance.CheckGameOver(this);
    }

    private void OnDrawGizmos()
    {
        Vector3 position = bulletSpawn.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + 50.0f * transform.forward);
    }

    /// <summary>
    /// Enable Player to shooting using the left mouse click
    /// </summary>
    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // create the bullet fromo the prefab
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * mBulletSpeed;
            // Destroy the bullet after 4s
            Destroy(bullet, 4.0f);
        }
    }

    //public void TakeDamage(int dmg)
    //{
    //    health -= dmg;
    //    healthBar.setHealth(health);
    //    if (health <= 0.0f)
    //    {
    //        Debug.Log("Game Over!");
    //    }
    //}

    //public void Attack()
    //{
    //    //throw new System.NotImplementedException();
    //}
}