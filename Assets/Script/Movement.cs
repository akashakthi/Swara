using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject MoveLeft;
    public GameObject MoveRight;
    public GameObject EfekGoyang;
    bool inputProcessed = true; // Menandakan apakah input sudah diproses atau tidak
    void Update()
    {

        if (MoveLeft == null || MoveRight == null)
        {
            Debug.LogError("btnAd atau btnArrow belum diassign di Inspector!");
            return;
        }

        // Tombol 'A' ditekan, geser ke posisi (-3, y)
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToPositionAd(new Vector2(-2.5f, MoveLeft.transform.position.y));
            Instantiate(EfekGoyang, new Vector3(-2.5f, -3.5f, 0), Quaternion.identity);

        }
        // Tombol 'D' ditekan, geser ke posisi (-2, y)
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveToPositionAd(new Vector2(-1.5f, MoveLeft.transform.position.y));
            Instantiate(EfekGoyang, new Vector3(-1.5f, -3.5f, 0), Quaternion.identity);
        }

        // Tombol 'Arah Kiri' ditekan, geser ke posisi (2, y)
        if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.J)))
        {
            MoveToPositionArrow(new Vector2(1.5f, MoveRight.transform.position.y));
            Instantiate(EfekGoyang, new Vector3(1.5f, -3.5f, 0), Quaternion.identity);
        }
        // Tombol 'Arah Kanan' ditekan, geser ke posisi (3, y)
        else if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.L)))
        {
            MoveToPositionArrow(new Vector2(2.5f, MoveRight.transform.position.y));
            Instantiate(EfekGoyang, new Vector3(2.5f, -3.5f, 0), Quaternion.identity);
        }
    }

    void MoveToPositionAd(Vector2 targetPositionAd)
    {
        // Perbarui posisi btnAd ke targetPosition
        MoveLeft.transform.position = targetPositionAd;

    }

    void MoveToPositionArrow(Vector2 targetPositionArrow)
    {
        // Perbarui posisi btnAd ke targetPosition
        MoveRight.transform.position = targetPositionArrow;

    }
   
}
