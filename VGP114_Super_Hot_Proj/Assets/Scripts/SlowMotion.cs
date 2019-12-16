using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    PlayerHud PlayerHud;

    private void Awake()
    {
        PlayerHud = FindObjectOfType<PlayerHud>();
    }


    void Update()
    {
        bool movement = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
        PlayerHud.UpdateClockImage(movement);
        Time.timeScale = movement ? 1f : 0.1f;
    }
}
