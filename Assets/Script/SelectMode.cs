using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour
{
    public void StoryMode()
    {
        SceneManager.LoadScene("SelectStory"); // Pindah ke Scene SelectMode
    }

    public void CasualMode()
    {
        SceneManager.LoadScene("LevelOne"); // Pindah ke Scene SelectMode
    }

    public void BackMainMenuy()
    {
        SceneManager.LoadScene("MainMenu"); // Pindah ke Scene SelectMode
    }
}
