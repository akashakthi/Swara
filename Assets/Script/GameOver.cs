using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float originalTimeScale;
    // Start is called before the first frame update

    public void nextlvlstory()
    {
        originalTimeScale = Time.timeScale;

        // Dapatkan nama scene yang sedang aktif
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Tentukan scene yang akan dimuat ulang berdasarkan nama scene saat ini
        if (currentSceneName == "LevelOne")
        {
            SceneManager.LoadScene("VisualOneEnd");
        }
        else if (currentSceneName == "LevelTwo")
        {
            SceneManager.LoadScene("VisualTwoEnd");
        }
        else if (currentSceneName == "LevelThree")
        {
            SceneManager.LoadScene("VisualThreeEndHapy");
        }
        Time.timeScale = 1;
        
    }

    public void retryLose()
    {
        SceneManager.LoadScene("VisualThreeEndSad");
        Time.timeScale = 1;
    }

    public void nextCasual()
    {
        SceneManager.LoadScene("CasualModeSelect");
        Time.timeScale = 1;
        
    }
    public void retry()
    {
        // Simpan nilai Time.timeScale saat ini
        originalTimeScale = Time.timeScale;

        // Dapatkan nama scene yang sedang aktif
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Tentukan scene yang akan dimuat ulang berdasarkan nama scene saat ini
        if (currentSceneName == "LevelOne")
        {
            SceneManager.LoadScene("LevelOne");
        }
        else if (currentSceneName == "LevelTwo")
        {
            SceneManager.LoadScene("LevelTwo");
        }
        else if (currentSceneName == "LevelThree")
        {
            SceneManager.LoadScene("LevelThree");
        }
        else if (currentSceneName == "CasualOne")
        {
            SceneManager.LoadScene("CasualOne");
        }
        else if (currentSceneName == "CasualTwo")
        {
            SceneManager.LoadScene("CasualTwo");
        }
        else
        {
            Debug.LogWarning("Scene tidak dikenali, tidak ada tindakan yang diambil.");
        }

        // Setelah level dimuat ulang, normalkan kembali Time.timeScale
        Time.timeScale = 1f; // Set ke nilai normal (1.0f)
    }

    public void backMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainmenu");
    }
}
