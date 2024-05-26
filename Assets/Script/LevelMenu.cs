using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        UpdateButtonInteractivity(unlockedLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ResetPlayerPrefs();
        }
    }

    private void UpdateButtonInteractivity(int unlockedLevel)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            buttons[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // Anda dapat menyesuaikan nilai-nilai RGBA
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
            buttons[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f); // Anda dapat menyesuaikan nilai-nilai RGBA
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }

    private void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        UpdateButtonInteractivity(1);
    }
}
