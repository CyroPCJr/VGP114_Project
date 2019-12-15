using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Goal")]
    public int Kills = 10;

    public static GameManager Instance { get; private set; }

    private const string gameOverScene = "GameOver";
    private const string winScene = "WinScene";

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Check whether the Player/ CharacterControl is Dead
    /// </summary>
    /// <param name="player"></param>
    public void CheckGameOver(CharacterControl player)
    {
        if (player)
        {
            if (player.GetComponent<Health>().isDead)
            {
                SceneManager.LoadScene(gameOverScene);
            }
        }

    }

    public void CheckGoalLevel(int kills)
    {
        if (Kills == kills)
        {
            SceneManager.LoadScene(winScene);
        }
    }

}