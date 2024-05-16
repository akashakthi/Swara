using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectMode"); // Pindah ke Scene SelectMode
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options"); // Pindah ke Scene Options
    }
    public void OpenHelp()
    {
        SceneManager.LoadScene("Help");
    }
    public void OpenCredit()
    {
        SceneManager.LoadScene("Credit"); // Pindah ke Scene Credit
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Hanya berhenti di editor Unity
#else
        Application.Quit(); // Keluar dari aplikasi saat di build
#endif 
    }
}
