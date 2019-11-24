using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject Player = null;
    private readonly float mMinDistance = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Player && Vector3.Distance(Player.transform.position, transform.position) < mMinDistance)
        {
            Vector3 lookVector = Player.transform.position - transform.position;
            //Debug.Log("D333333DD!!!");

            //transform.forward = lookVector.normalized;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
           transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if (Player != null) {
            if (Vector3.Distance(Player.transform.position, transform.position) < mMinDistance)
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawLine(transform.position, Player.transform.position);
        }

        Vector3 position = transform.position;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(position, position + 3.0f * transform.forward);
    }
}
