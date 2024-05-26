using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string targetSceneName = "";

    void Start()
    {
        // Mendapatkan nama scene saat ini
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Menentukan scene tujuan berdasarkan scene saat ini
        switch (currentSceneName)
        {
            case "LoadingOne":
                targetSceneName = "LevelOne";
                break;
            case "LoadingTwo":
                targetSceneName = "LevelTwo";
                break;
            case "LoadingThree":
                targetSceneName = "LevelThree";
                break;
            case "LoadingCasualOne":
                targetSceneName = "CasualOne";
                break;
            case "LoadingCasualTwo":
                targetSceneName = "CasualTwo";
                break;
            case "LoadingCasualThree":
                targetSceneName = "CasualThree";
                break;
            case "LoadingCasualFour":
                targetSceneName = "CasualFour";
                break;
            case "LoadingCasualFive":
                targetSceneName = "CasualFive";
                break;




            // Tambahkan case lain jika diperlukan untuk scene lainnya
            default:
                Debug.LogError("Scene not recognized!");
                break;
        }

        // Memanggil method untuk memuat scene tujuan setelah 5 detik
        Invoke("LoadTargetScene", 5f);
    }

    void LoadTargetScene()
    {
        // Memuat scene tujuan
        SceneManager.LoadScene(targetSceneName);
    }
}
