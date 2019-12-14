using UnityEngine;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    private int mKills;

    private Text mTextScore;
    private Image mClockImage;

    private Color mColor;

    private void Awake()
    {
        mTextScore = GetComponentInChildren<Text>();
        mClockImage = GetComponentInChildren<Image>();
        mColor = mClockImage.color;
    }

    public void UpdateKills()
    {
        mKills++;
        mTextScore.text = $"Kills: {mKills}";
        // if reach the goals, win the level
        GameManager.Instance.CheckGoalLevel(mKills);
    }

    public void UpdateClockImage(bool changeAlpha)
    {
        mColor.a = changeAlpha ? 1f : 0f;
        mClockImage.color = mColor;
    }
}
