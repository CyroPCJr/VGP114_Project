using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //static Animator anim;
    public float speed;
    public float rotationSpeed;
    public float normalSpeed;


    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Moving
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            translation *= Time.deltaTime * normalSpeed;
            
            transform.Translate(0, 0, translation);
           

            // Jumping trigger when press space
            //------- Running Jumping --------
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    anim.SetTrigger("isRunJumping");
            //}


            //anim.SetBool("isRunning", true);
            //anim.SetBool("isIdle", false);

        }
        else
        {
            // Jumping trigger when press space
            //------- In place Jumping --------
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    anim.SetTrigger("isJumping");
            //}

            //anim.SetBool("isRunning", false);
            //anim.SetBool("isIdle", true);
        }

    }
}
