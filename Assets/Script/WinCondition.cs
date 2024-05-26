using System.Collections;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject Win;
    public GameObject videoJJ;
    public AudioSource audioSource;
    public float fadeDuration = 1f; // Durasi untuk audio fade out dan transisi
    public GameObject bgWin;
    public GameObject bgLose;
    public GameObject WinButton;
    public GameObject LoseButton;

    void CheatWin()
    {
        if (Input.GetKeyUp(KeyCode.U))
        {
            // Mulai coroutine untuk menunggu 2 detik sebelum mengaktifkan objek Win dan menghentikan waktu dalam game
            StartCoroutine(ActivateWinAfterDelay(fadeDuration));

            bgWin.SetActive(true);
            WinButton.SetActive(true);

            LoseButton.SetActive(false);
            bgLose.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Memeriksa apakah objek yang bertabrakan memiliki tag "win"
        if (other.CompareTag("win"))
        {
            // Mulai coroutine untuk menunggu 2 detik sebelum mengaktifkan objek Win dan menghentikan waktu dalam game
            StartCoroutine(ActivateWinAfterDelay(fadeDuration));

            bgWin.SetActive(true);
            WinButton.SetActive(true);

            LoseButton.SetActive(false);
            bgLose.SetActive(false);
        }
    }

    IEnumerator ActivateWinAfterDelay(float delay)
    {
        // Mulai fade out audio
        StartCoroutine(FadeOutAudio(audioSource, fadeDuration));

        // Menunggu selama 'delay' detik
        yield return new WaitForSeconds(delay);

        // Mengaktifkan objek Win dengan transisi halus
        StartCoroutine(SmoothSetActive(Win, true, fadeDuration));

        // Menunggu selama durasi fade untuk memastikan transisi halus selesai
        yield return new WaitForSeconds(fadeDuration);

        // Menghentikan waktu dalam game
        Time.timeScale = 0;

        // Menonaktifkan videoJJ
        videoJJ.SetActive(false);
    }

    IEnumerator FadeOutAudio(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        audioSource.Pause();
        audioSource.volume = startVolume; // Kembalikan volume ke nilai awal
    }

    IEnumerator SmoothSetActive(GameObject obj, bool active, float duration)
    {
        CanvasGroup canvasGroup = obj.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = obj.AddComponent<CanvasGroup>();
        }

        float startAlpha = canvasGroup.alpha;
        float endAlpha = active ? 1f : 0f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
        obj.SetActive(active);
    }
}
