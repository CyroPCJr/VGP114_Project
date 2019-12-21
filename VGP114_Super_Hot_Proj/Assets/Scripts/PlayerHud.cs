using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    private int mKills;
    private int mEnemys;
    public Text mTextScore;
    public Text mTextEnemy;

    private void Awake()
    {
        //mTextScore = GetComponentInChildren<Text>();
        //mTextEnemy = GetComponentInChildren<Text>();
        mEnemys = 11;
    }

    public void UpdateKills()
    {
        mKills++;
        mTextScore.text = $"Kills: {mKills}";
        UpdateEnemyLeft();
        // if reach the goals, win the level
        GameManager.Instance.CheckGoalLevel(mKills);
    }

    public void UpdateEnemyLeft()
    {
        mEnemys--;
        mTextEnemy.text = $"Total: {mEnemys}";
    }
}
