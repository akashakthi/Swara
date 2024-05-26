using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSong : MonoBehaviour
{
    public void SelectCasualOne()
    {
        SceneManager.LoadScene("LoadingCasualOne");
    }

    public void SelectCasualTwo()
    {
        SceneManager.LoadScene("LoadingCasualTwo");
    }

    public void SelectCasualThree()
    {
        SceneManager.LoadScene("LoadingCasualThree");
    }

    public void SelectCasualFour()
    {
        SceneManager.LoadScene("LoadingCasualFour");
    }


    public void SelectCasualFive()
    {
        SceneManager.LoadScene("LoadingCasualFive");
    }

    public void BackSelectMode()
    {
        SceneManager.LoadScene("SelectMode");
    }
}
