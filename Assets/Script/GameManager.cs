using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isMusicEnabled = true; // variabel untuk menandai apakah musik diaktifkan atau tidak
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource != null && isMusicEnabled && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // Menambahkan callback untuk mendeteksi perubahan scene
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Callback yang akan dipanggil ketika scene baru dimuat
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Memeriksa jika scene yang dimuat bukan "LevelOne"
        if (scene.name != "VisualOne"  && scene.name != "LoadingOne" && scene.name != "LevelOne" && scene.name != "VisualOneEnd" 
            && scene.name != "LoadingTwo" && scene.name != "VisualTwo" && scene.name != "LevelTwo" && scene.name != "VisualTwoEnd" 
            && scene.name != "LoadingThree" && scene.name != "VisualThree" && scene.name != "LevelThree" && scene.name != "VisualThreeEndSad" && scene.name != "VisualThreeEndHappy"
            && scene.name != "LoadingCasualOne" && scene.name != "LoadingCasualTwo" && scene.name != "LoadingCasualThree" && scene.name != "LoadingCasualFour"
            && scene.name != "LoadingCasualFive" && scene.name != "CasualOne" && scene.name != "CasualTwo" && scene.name != "CasualThree"&& scene.name != "CasualFour" && scene.name != "CasualFive")
        {
            // Memeriksa apakah musik diaktifkan dan tidak sedang diputar
            if (isMusicEnabled && audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play(); // Memulai pemutaran musik jika belum diputar
            }
        }
        else
        {
            // Mematikan musik jika scene yang dimuat adalah "LevelOne"
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    // Metode untuk mengatur pemutaran musik
    public void ToggleMusic(bool isEnabled)
    {
        isMusicEnabled = isEnabled;

        if (audioSource != null)
        {
            if (isEnabled && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else if (!isEnabled && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
