using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public GameObject slowMotion;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //slowMotion.SetActive(false);
            Time.timeScale = 1.0f;
            Debug.Log("key down");
        }
        else
        {
            //slowMotion.SetActive(true);
            Time.timeScale = 0.1f;
            Debug.Log("slow motion time");
        }
    }
}
