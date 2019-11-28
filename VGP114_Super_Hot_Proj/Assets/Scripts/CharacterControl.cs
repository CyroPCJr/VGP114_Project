using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private readonly float mSpeed = 10.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 tempVect = new Vector3(h, 0, v);
        tempVect = tempVect.normalized * mSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + tempVect);
    }

}