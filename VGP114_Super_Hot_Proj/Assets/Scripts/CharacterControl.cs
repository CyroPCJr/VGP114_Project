using UnityEngine;

public class CharacterControl : MonoBehaviour //, ICharacterAction
{

    [Header("SFX")]
    public AudioSource gunFire;
    public AudioSource gunShell;
    public AudioSource footStep;

    private bool footSoundPlay = false;
    private float count = 0.0f;

    private Animation mAnimation;
    public GameObject HandGun;


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

    [SerializeField]
    private ParticleSystem mMuzzleFlash;

    private readonly float mSpeed = 15.0f; // player speed
    private readonly float groundDistance = 0.4f;
    private readonly float gravity = -9.81f;
    private readonly float mBulletSpeed = 20.0f; // bullet speed
    private bool isGrounded;
    Vector3 velocity;

    private Camera mCamera;

    private void Awake()
    {
        Cursor.visible = false;
        mCamera = FindObjectOfType<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        // play sound when move
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //cameraAnimation = myCamera.GetComponent<Animation>();

            float countTime = Time.deltaTime;
            count += countTime;
            if (countTime < 0.05f && footSoundPlay == false)
            {
                footStep.Play();
                //cameraAnimation.Play("Camera");
                mCamera.GetComponent<Animation>().Play("Camera");
                footSoundPlay = true;
            }
            if (count > 0.5f)
            {
                footSoundPlay = false;
                count = 0.0f;
            }

        }

        Shooting();
    }

    private void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

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
    }

    private void OnDrawGizmos()
    {
        Vector3 position = bulletSpawn.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + 50.0f * transform.forward);
    }


    private float timerAttack = 0f;
    private readonly float fireRate = 1f;
    /// <summary>
    /// Enable Player to shooting using the left mouse click
    /// </summary>
    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timerAttack)
        {
            // timer to let the player shoot every second instead make a burst shot
            timerAttack = Time.time + fireRate;
            mAnimation = HandGun.GetComponent<Animation>();
            mAnimation.Play("GunRecoil");

            gunFire.Play();
            gunShell.Play();

            // trigger the muzzle flash
            mMuzzleFlash.time = 0;
            mMuzzleFlash.Play();

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * mBulletSpeed;
            // Destroy the bullet after 10s
            Destroy(bullet, 10f);
        }
    }
}