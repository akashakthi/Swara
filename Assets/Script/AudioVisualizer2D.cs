using UnityEngine;

public class AudioVisualizer2D : MonoBehaviour
{
    public AudioSource audioSource;
    public float scale = 10f; // Besar skala gerakan
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Ambil data spektrum audio
        float[] spectrumData = new float[256]; // Buat array untuk menyimpan data spektrum
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // Hitung rata-rata dari semua level spektrum
        float average = 0f;
        for (int i = 0; i < spectrumData.Length; i++)
        {
            average += spectrumData[i];
        }
        average /= spectrumData.Length;

        // Gunakan nilai rata-rata untuk menggerakkan objek
        Vector3 newPosition = initialPosition;
        newPosition.y += average * scale; // Gunakan nilai rata-rata sebagai skala gerakan
        transform.position = newPosition;
    }
}
