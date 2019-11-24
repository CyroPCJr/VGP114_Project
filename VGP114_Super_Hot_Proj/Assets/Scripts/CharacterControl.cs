using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Vector3 mMovement = Vector3.zero;
    private readonly float mSpeed = 10.0f;

    private void MouseMovement()
    {
        //mMouseLookRot.y += Input.GetAxis("Mouse X");
        //mMouseLookRot.x += -Input.GetAxis("Mouse Y");
        //mMouseLookRot.x = Mathf.Clamp(mMouseLookRot.x, -15f, 15f);
        //transform.eulerAngles = new Vector3(0, mMouseLookRot.y) * lookSpeed;
        //transform.localRotation = Quaternion.Euler(mMouseLookRot.x * lookSpeed, 0, 0);
        //transform.rotation = Quaternion.Euler(Input.GetAxis("Mouse X"), 0.0f,0.0f);
    }

    private void KeyboardMovement()
    {
        // Make movement foward and bacck, left and right
        mMovement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        transform.position += mMovement * mSpeed * Time.deltaTime;
    }



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MouseMovement();
        KeyboardMovement();
    }
}
