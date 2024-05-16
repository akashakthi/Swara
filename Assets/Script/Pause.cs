using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject videoJJ;
    private float originalTimeScale;
    public AudioSource audioSource; // Komponen AudioSource untuk audio permainan
    // Start is called before the first frame update

    public void pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        audioSource.Pause();
        videoJJ.SetActive(false);

        PostProcessVolume ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        ppVolume.enabled = !ppVolume.enabled;
        
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
        // Simpan nilai Time.timeScale saat ini
        originalTimeScale = Time.timeScale;

        // Setelah level dimuat ulang, normalkan kembali Time.timeScale
        Time.timeScale = 1f; // Set ke nilai normal (1.0f)
    }
    public void restart()
    {
        // Simpan nilai Time.timeScale saat ini
        originalTimeScale = Time.timeScale;

        // Load ulang level
        SceneManager.LoadScene("LevelOne");

        // Setelah level dimuat ulang, normalkan kembali Time.timeScale
        Time.timeScale = 1f; // Set ke nilai normal (1.0f)
    }

    public void restartLevelTwo()
    {
        // Simpan nilai Time.timeScale saat ini
        originalTimeScale = Time.timeScale;

        // Load ulang level
        SceneManager.LoadScene("LevelTwo");

        // Setelah level dimuat ulang, normalkan kembali Time.timeScale
        Time.timeScale = 1f; // Set ke nilai normal (1.0f)
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        audioSource.Play();
        videoJJ.SetActive(true);

        PostProcessVolume ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        ppVolume.enabled = false;

        Debug.Log("Efek Post-Processing telah dinonaktifkan.");

    }

}
