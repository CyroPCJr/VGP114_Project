using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("CharacterTestHolodeckScene");
    }

    public void LevelSelect(string levelName) => SceneManager.LoadScene(levelName);

}
