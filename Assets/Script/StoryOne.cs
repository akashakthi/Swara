using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryOne : MonoBehaviour
{
    public void levelOne()
    {
        SceneManager.LoadScene("LevelOne"); // Pindah ke Scene SelectMode
    }

    public void StoryMode()
    {
        SceneManager.LoadScene("SelectStory"); // Pindah ke Scene SelectMode
    }


}
