using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    private int mKills;
    private Text mTextScore;

    private void Awake()
    {
        mTextScore = GetComponentInChildren<Text>();
    }

    public void UpdateKills()
    {
        mKills++;
        mTextScore.text = $"Kills: {mKills}";
        // if reach the goals, win the level
        GameManager.Instance.CheckGoalLevel(mKills);
    }
}
