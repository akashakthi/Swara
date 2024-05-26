using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyButton : MonoBehaviour
{
    public AudioSource audioSource; // Referensi ke AudioSource
    public float fadeDuration = 1.0f; // Durasi fade dalam detik

    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(FadeOutAndLoadScene("mainmenu"));
        }
    }

    IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        float startVolume = audioSource.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0;
        SceneManager.LoadScene(sceneName);
    }
}
