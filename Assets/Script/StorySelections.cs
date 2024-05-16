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
        int levelAt = PlayerPrefs.GetInt("LevelAt", 2);
        for (int i = 0; i < StoryLevelBtn.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                StoryLevelBtn[i].interactable = false;
                // Mengganti sprite tombol dengan sprite yang telah ditentukan saat tidak dapat diinteraksi
               // StoryLevelBtn[i].GetComponent<Image>().sprite = disabledSprite;
                // Menambahkan efek Color Tint untuk menggelapkan sprite
                StoryLevelBtn[i].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f); // Anda dapat menyesuaikan nilai-nilai RGBA sesuai kebutuhan
            }
        }
    }


}
