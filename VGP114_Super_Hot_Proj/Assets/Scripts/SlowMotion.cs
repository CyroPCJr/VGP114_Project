using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public GameObject slowMotion;
    // Start is called before the first frame update
    void Start()
    {
        //slowMotion.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            //slowMotion.SetActive(false);
            Time.timeScale = 1.0f;
            Debug.Log("key down");
        }
        else
        {
            //slowMotion.SetActive(true);
            Time.timeScale = 0.15f;
            Debug.Log("slow motion time");
        }
    }
}
