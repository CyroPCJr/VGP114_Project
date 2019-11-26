using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Vector3 mMovement = Vector3.zero;
    private readonly float mSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        mMovement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        transform.position += mMovement * mSpeed * Time.deltaTime;
    }

}