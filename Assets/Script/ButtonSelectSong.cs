using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler
{
    public Button[] buttonSelect;
    public GameObject[] gambarCasual;

    private void Start()
    {
        // Pastikan semua gambar dalam keadaan tidak aktif pada awalnya
        foreach (GameObject gambar in gambarCasual)
        {
            gambar.SetActive(false);
        }

        // Menambahkan event listener untuk setiap button
        for (int i = 0; i < buttonSelect.Length; i++)
        {
            int index = i; // Local copy for the anonymous function
            buttonSelect[i].gameObject.AddComponent<HoverHandler>().Init(this, index);
        }
    }

    public void OnHover(int index)
    {
        // Nonaktifkan semua gambar
        foreach (GameObject gambar in gambarCasual)
        {
            gambar.SetActive(false);
        }

        // Aktifkan gambar sesuai dengan indeks
        if (index >= 0 && index < gambarCasual.Length)
        {
            gambarCasual[index].SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Tidak digunakan, karena kita menggunakan HoverHandler untuk menangani event ini.
    }
}

public class HoverHandler : MonoBehaviour, IPointerEnterHandler
{
    private ButtonHover buttonHover;
    private int index;

    public void Init(ButtonHover buttonHover, int index)
    {
        this.buttonHover = buttonHover;
        this.index = index;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonHover.OnHover(index);
    }
}
