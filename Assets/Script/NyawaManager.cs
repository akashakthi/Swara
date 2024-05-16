using UnityEngine;
using UnityEngine.UI;

public class NyawaManager : MonoBehaviour
{
    public int nyawaAwal = 5;
    private int nyawaSaatIni;
    public GameObject[] nyawaObjects; // Array dari game object yang merepresentasikan nyawa
    public GameObject gameOverScreen; // Game object yang merepresentasikan layar game over
    public AudioSource audioSource; // Komponen AudioSource untuk audio permainan
    private bool gameOver = false; // Penanda apakah game over telah terjadi

    void Start()
    {
        nyawaSaatIni = nyawaAwal;
        Debug.Log("Nyawa Awal: " + nyawaSaatIni);
        UpdateUI();
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
                // Mengaktifkan game object GameOver
                gameOverScreen.SetActive(true);
                // Tambahkan logika lain yang Anda inginkan saat game over
                Time.timeScale = 0;
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

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Game Over");
            gameOver = true;
            // Menonaktifkan audio saat game over
            audioSource.Stop();
            // Mengaktifkan game object GameOver
            gameOverScreen.SetActive(true);
           
        }
    }
    */
}
