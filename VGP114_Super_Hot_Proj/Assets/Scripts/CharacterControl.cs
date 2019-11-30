using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private readonly float mSpeed = 10.0f;
    private float gravity = -9.81f;
    private Rigidbody rb;



    public HealthBar healthBar;
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    int health = 5;
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

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * h + transform.forward * v;
        controller.Move(move * mSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //play shooting
        if (Input.GetMouseButtonDown(0))
        {
            // create the bullet fromo the prefab
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;

            // Destroy the bullet after 4s
            Destroy(bullet, 4);


        }
        
    }

    private void OnDrawGizmos()
    {
        Vector3 position = bulletSpawn.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + 50.0f * transform.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet")
        {
            if(health == 0)
            {
                
            }
            else
            {
                health -= 1;
                healthBar.setHealth(health);
            }
           
        }
    }

}