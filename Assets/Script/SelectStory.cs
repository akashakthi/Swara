using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStory : MonoBehaviour
{
    public void StoryOne()
    {
        SceneManager.LoadScene("VisualOne"); // Pindah ke Scene SelectMode
    }

    public void StoryTwo()
    {
        SceneManager.LoadScene("VisualTwo"); // Pindah ke Scene SelectMode
    }

    public void StoryThree()
    {
        SceneManager.LoadScene("VisualThree"); // Pindah ke Scene SelectMode
    }


    public void BackBtn()
    {
        SceneManager.LoadScene("SelectMode"); // Pindah ke Scene SelectMode
    }
}
