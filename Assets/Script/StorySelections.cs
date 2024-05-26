using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySelections : MonoBehaviour
{
    public Button[] StoryLevelBtn;
    //public Sprite disabledSprite; // Sprite yang akan digunakan saat tombol tidak dapat diinteraksi

    void Start()
    {
        UpdateStoryButtons();
        AttachButtonListeners();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ResetPlayerProgress();
            UpdateStoryButtons();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            IncrementPlayerProgress();
            UpdateStoryButtons();
        }
    }

    void AttachButtonListeners()
    {
        for (int i = 0; i < StoryLevelBtn.Length; i++)
        {
            int index = i; // Capture the current index
            StoryLevelBtn[i].onClick.AddListener(() => OnStoryButtonClicked(index));
        }
    }

    void OnStoryButtonClicked(int buttonIndex)
    {
        int levelAt = PlayerPrefs.GetInt("LevelAt", 2);
        if (buttonIndex + 2 <= levelAt)
        {
            IncrementPlayerProgress();
            UpdateStoryButtons();
        }
    }

    void UpdateStoryButtons()
    {
        int levelAt = PlayerPrefs.GetInt("LevelAt", 2);
        for (int i = 0; i < StoryLevelBtn.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                StoryLevelBtn[i].interactable = false;

                StoryLevelBtn[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // Anda dapat menyesuaikan nilai-nilai RGBA sesuai kebutuhan
            }
            else
            {
                StoryLevelBtn[i].interactable = true;
                StoryLevelBtn[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f); // Kembalikan warna asli tombol
            }
        }
    }

    void ResetPlayerProgress()
    {
        PlayerPrefs.SetInt("LevelAt", 2);
        PlayerPrefs.Save();
    }

    void IncrementPlayerProgress()
    {
        int levelAt = PlayerPrefs.GetInt("LevelAt", 2);
        PlayerPrefs.SetInt("LevelAt", levelAt + 1);
        PlayerPrefs.Save();
    }
}
