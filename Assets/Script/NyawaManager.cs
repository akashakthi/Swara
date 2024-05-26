using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NyawaManager : MonoBehaviour
{
    public int nyawaAwal = 5;
    private int nyawaSaatIni;
    public GameObject[] nyawaObjects; // Array dari game object yang merepresentasikan nyawa
    public GameObject gameOverScreen; // Game object yang merepresentasikan layar game over
    public AudioSource audioSource; // Komponen AudioSource untuk audio permainan
    private bool gameOver = false; // Penanda apakah game over telah terjadi
    private CanvasGroup canvasGroup; // Komponen CanvasGroup untuk mengatur transparansi
    public GameObject bgWin;
    public GameObject bgLose;
    public GameObject WinButton;
    public GameObject LoseButton;

    void Start()
    {
        nyawaSaatIni = nyawaAwal;
        Debug.Log("Nyawa Awal: " + nyawaSaatIni);
        UpdateUI();

        // Tambahkan komponen CanvasGroup ke gameOverScreen jika belum ada
        canvasGroup = gameOverScreen.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameOverScreen.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0; // Mulai dengan alpha 0 (transparan)
        gameOverScreen.SetActive(false); // Pastikan gameOverScreen tidak aktif pada awalnya
    }

    public void KurangiNyawa(int jumlah)
    {
        if (!gameOver)
        {
            nyawaSaatIni -= jumlah;
            if (nyawaSaatIni == 0)
            {
                Debug.Log("Game Over");
                gameOver = true;
                // Menonaktifkan audio saat game over
                audioSource.Stop();
                // Mengaktifkan game object GameOver dan mulai fade-in
                gameOverScreen.SetActive(true);
                StartCoroutine(FadeInGameOverScreen());
                // Tambahkan logika lain yang Anda inginkan saat game over
                Time.timeScale = 0;

                bgWin.SetActive(false);
                WinButton.SetActive(false);

                bgLose.SetActive(true);
                LoseButton.SetActive(true);
            }
            else
            {
                Debug.Log("Nyawa Tersisa: " + nyawaSaatIni);
            }
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < nyawaObjects.Length; i++)
        {
            if (i < nyawaSaatIni)
                nyawaObjects[i].SetActive(true); // Mengaktifkan game object yang merepresentasikan nyawa
            else
                nyawaObjects[i].SetActive(false); // Menonaktifkan game object yang tidak merepresentasikan nyawa
        }
    }

    IEnumerator FadeInGameOverScreen()
    {
        float duration = 1.0f; // Durasi fade-in dalam detik
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.unscaledDeltaTime; // Menggunakan Time.unscaledDeltaTime agar tidak terpengaruh oleh Time.timeScale
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / duration);
            yield return null;
        }
    }
}