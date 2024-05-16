using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private float originalTimeScale;
    // Start is called before the first frame update
    public void retry()
    {
        // Simpan nilai Time.timeScale saat ini
        originalTimeScale = Time.timeScale;

        // Load ulang level
        SceneManager.LoadScene("LevelOne");

        // Setelah level dimuat ulang, normalkan kembali Time.timeScale
        Time.timeScale = 1f; // Set ke nilai normal (1.0f)
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void backMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
