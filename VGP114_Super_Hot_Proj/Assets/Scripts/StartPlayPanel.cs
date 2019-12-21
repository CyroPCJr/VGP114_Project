using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlayPanel : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void StartPlayButton()
    {
        SceneManager.LoadScene(1);
    }
}
