using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{

    public void PlayAgain()
    {
        SceneManager.LoadScene("CharacterTestHolodeckScene");
    }

    public void LevelSelect(string levelName) => SceneManager.LoadScene(levelName);

}
