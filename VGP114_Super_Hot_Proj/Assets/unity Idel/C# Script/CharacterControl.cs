using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    static Animator anim;
    public float speed = 0.00005f;
    public float rotationSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jumping trigger when press space
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isJumping");
        }

        // Moving
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(translation != 0)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);

        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

    }
}
