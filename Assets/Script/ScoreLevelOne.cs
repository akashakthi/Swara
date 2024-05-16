using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLevelOne : MonoBehaviour
{

    // Variabel untuk menyimpan UI Text atau komponen lainnya untuk menampilkan skor
    // public Text textScoreUI; // Pastikan untuk mengimpor UnityEngine.UI jika menggunakan UI Text

    public GameObject skoreA;
    public GameObject skoreB;
    public GameObject skoreC;
    public GameObject skoreD;
    public GameObject skoreE;

    void Start()
    {
        // Set nilai awal skor ke 0 jika belum diatur sebelumnya
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
    }

    public void AddScore(int score)
    {
        // Menambahkan nilai skor
        int currentScore = PlayerPrefs.GetInt("Score");
        currentScore += score;
        PlayerPrefs.SetInt("Score", currentScore);

        // Memanggil ScoreLevelOne setiap kali skor berubah
        Score();
    }

    public void Score()
    {
        // Mendapatkan nilai skor saat ini
        int currentScore = GetCurrentScore();

        // Tampilkan nilai skor saat ini di console atau UI
        Debug.Log("Current Score: " + currentScore);

        // Atur aktivasi game object berdasarkan nilai skor
        if (currentScore <= 5220)
        {
            skoreA.SetActive(true);
            skoreB.SetActive(false);
            skoreC.SetActive(false);
            skoreD.SetActive(false);
            skoreE.SetActive(false);
        }
        else if (currentScore <= 4640)
        {
            skoreA.SetActive(false);
            skoreB.SetActive(true);
            skoreC.SetActive(false);
            skoreD.SetActive(false);
            skoreE.SetActive(false);
        }
        else if (currentScore <= 4060)
        {
            skoreA.SetActive(false);
            skoreB.SetActive(false);
            skoreC.SetActive(true);
            skoreD.SetActive(false);
            skoreE.SetActive(false);
        }
        else if (currentScore <= 3480)
        {
            skoreA.SetActive(false);
            skoreB.SetActive(false);
            skoreC.SetActive(false);
            skoreD.SetActive(true);
            skoreE.SetActive(false);
        }
        else
        {
            skoreA.SetActive(false);
            skoreB.SetActive(false);
            skoreC.SetActive(false);
            skoreD.SetActive(false);
            skoreE.SetActive(true);
        }
    }

    public int GetCurrentScore()
    {
        // Mengambil nilai skor saat ini dari PlayerPrefs
        int currentScore = PlayerPrefs.GetInt("Score");
        return currentScore;
    }
}
