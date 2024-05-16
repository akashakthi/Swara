using UnityEngine;

public class DeteksiBawah : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            // Hancurkan game object "note" yang berkolisi dengan objek "Bawah"
            Destroy(other.gameObject);

            // Panggil metode KurangiNyawa pada NyawaManager
            GameObject nyawaManagerObject = GameObject.FindWithTag("NyawaManager");
            if (nyawaManagerObject != null)
            {
                NyawaManager nyawaManager = nyawaManagerObject.GetComponent<NyawaManager>();
                if (nyawaManager != null)
                {
                    nyawaManager.KurangiNyawa(1); // Kurangi satu nyawa setiap kali terjadi tabrakan
                }
            }
        }
    }
}
