using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Activator : MonoBehaviour
{
    public Text totalText;


    int totalPerfect = 0;
    int totalGood = 0;
    int totalBad = 0;

    
    public GameObject skoreA;
    public GameObject skoreB;
    public GameObject skoreC;
    public GameObject skoreD;
    public GameObject skoreE;
    public GameObject hoekObject;
    public GameObject bintangObject;
    public GameObject loveObject;
    private int hoekCount = 0;
    private int bintangCount = 0;
    private int loveCount = 0;

    SpriteRenderer sr;
    bool active = false;
    GameObject note;
    Color old;
    bool isAKeyPressed = false;
    bool isDKeyPressed = false;
    bool isRightArrowPressed = false;
    bool isLeftArrowPressed = false;
    bool inputProcessed = true; // Menandakan apakah input sudah diproses atau tidak
    public bool createMode;
    public GameObject n;
    public GameObject perfectObject;
    public GameObject goodObject;
    public GameObject badObject;
    float activeDuration = 0.1f;
    public GameObject Efek;

    // Variabel untuk mengontrol getaran kamera
    public float shakeDuration = 0.15f;
    public float shakeMagnitude = 0.1f;

    CameraShake cameraShake;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cameraShake = Camera.main.GetComponent<CameraShake>(); // Mengambil komponen CameraShake dari kamera utama

        // Inisialisasi skor ke nol saat permainan dimulai
        PlayerPrefs.SetInt("Score", 0);

        // Menonaktifkan game object baru pada awal permainan
        perfectObject.SetActive(false);
        goodObject.SetActive(false);
        badObject.SetActive(false);

        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            // Panggil ScoreLevelOne hanya jika berada di scene "LevelOne"
            ScoreLevelOne(GetCurrentScore());
        }
        else if (SceneManager.GetActiveScene().name == "LeveTwo")
        {
            // Panggil ScoreLevelTwo hanya jika berada di scene "LevelTwo"
            ScoreLevelTwo(GetCurrentScore());
        }
        else if (SceneManager.GetActiveScene().name == "LeveThree")
        {
            // Panggil ScoreLevelTwo hanya jika berada di scene "LevelThree"
            ScoreLevelThree(GetCurrentScore());
        }
        else if (SceneManager.GetActiveScene().name == "CasualOne")
        {
            // Panggil ScoreLevelTwo hanya jika berada di scene "CasualOne"
            ScoreCasualOne(GetCurrentScore());
        }
        else if (SceneManager.GetActiveScene().name == "CasualTwo")
        {
            // Panggil ScoreLevelTwo hanya jika berada di scene "CasualTwo"
            ScoreCasualTwo(GetCurrentScore());
        }

        else if (SceneManager.GetActiveScene().name == "CasualThree")
        {
            // Panggil ScoreLevelTwo hanya jika berada di scene "CasualThree"
            ScoreCasualThree(GetCurrentScore());
        }
        else if (SceneManager.GetActiveScene().name == "CasualFour")
        {
            // Panggil ScoreLevelTwo hanya jika berada di scene "CasualFour"
            ScoreCasualFour(GetCurrentScore());
        }

        else if (SceneManager.GetActiveScene().name == "CasualFive")
        {
            // Panggil ScoreLevelTwo hanya jika berada di scene "CasualFive"
            ScoreCasualFive(GetCurrentScore());
        }
    }

    void Update()
    {
        ShowTotal();
        if (createMode)
        {
            if (inputProcessed)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    InstantiateNoteObject(-1.5f);
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    InstantiateNoteObject(-2.5f);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.L))
                {
                    InstantiateNoteObject(2.5f);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.J))
                {
                    InstantiateNoteObject(1.5f);
                }
            }
        }
        else
        {
            if (inputProcessed && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.J)))
            {
                StartCoroutine(Pressed());
            }
        }
    }

    void InstantiateNoteObject(float positionX)
    {
        GameObject newNote = Instantiate(n, new Vector3(positionX, -3.5f, 0f), Quaternion.identity);
        // Menggerakkan objek catatan sesuai dengan input yang diberikan
        newNote.GetComponent<Rigidbody2D>().velocity = Vector2.up * 2.0f; // Misalnya, menggerakkan objek ke atas dengan kecepatan 2
        inputProcessed = false; // Set inputProcessed menjadi false saat instantiasi objek catatan
    }





    IEnumerator Pressed()
    {
        inputProcessed = false; // Set inputProcessed menjadi false saat menjalankan Coroutine
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = Color.white;
        inputProcessed = true; // Set inputProcessed menjadi true setelah menyelesaikan Coroutine
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            isDKeyPressed = false;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            isAKeyPressed = false;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.L))
        {
            isRightArrowPressed = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.J))
        {
            isLeftArrowPressed = false;
        }
        inputProcessed = true; // Set inputProcessed menjadi true saat menyelesaikan proses input apapun
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            // Menghitung posisi kolisi relatif terhadap Collider
            float relativePosition = Mathf.Abs(transform.position.y - col.transform.position.y) / (GetComponent<BoxCollider2D>().size.y / 2);

            // Menentukan nilai skor berdasarkan persentase posisi kolisi
            int scoreToAdd = 0;
            string feedbackText = "";

            if (relativePosition >= 0.81f)
            {
                scoreToAdd = 10;
                feedbackText = "Perfect!";
                StartCoroutine(ActivateObject(perfectObject));
                totalPerfect++; // Menambah total perfect
                loveCount++; // Menghitung jumlah kondisi perfect
                
                if (loveCount >= 10)
                {
                    StartCoroutine(ActivateObject(loveObject));
                }
            }
            else if (relativePosition >= 0.66f)
            {
                scoreToAdd = 8;
                feedbackText = "Good!";
                StartCoroutine(ActivateObject(goodObject));
                totalGood++; // Menambah total good
                loveCount++;
                if (loveCount >= 5)
                {
                    StartCoroutine(ActivateObject(bintangObject));
                }
            }
            else
            {
                scoreToAdd = 5; // atau sesuaikan sesuai kebutuhan
                feedbackText = "Bad!";
                StartCoroutine(ActivateObject(badObject));
                totalBad++; // Menambah total bad
                hoekCount++; // Menghitung jumlah kondisi bad
                if (hoekCount <= 3)
                {
                    StartCoroutine(ActivateObject(hoekObject));
                }
            }

            AddScore(scoreToAdd);
            active = false;
            Destroy(col.gameObject);
            Instantiate(Efek, transform.position, Quaternion.identity);
            // Panggil fungsi untuk menggetarkan kamera
            cameraShake.ShakeCamera(shakeDuration, shakeMagnitude);

            // Menampilkan feedback
            Debug.Log(feedbackText);
        }
    }

    private IEnumerator ActivateObject(GameObject obj, bool deactivateAfterDelay = false)
    {
        obj.SetActive(true);
        if (deactivateAfterDelay)
        {
            yield return new WaitForSeconds(0.5f);
            obj.SetActive(false);
        }
    }

    void ShowTotal()
    {
        totalText.text = "" + totalPerfect + "\n" +
                    "" + totalGood + "\n" +
                    "" + totalBad;

        Debug.Log("Total Perfect: " + totalPerfect);
        Debug.Log("Total Good: " + totalGood);
        Debug.Log("Total Bad: " + totalBad);
    }

    IEnumerator ActivateObject(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(activeDuration);
        obj.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            active = false;
            note = null;
        }
    }

    public void AddScore(int score)
    {
        int currentScore = PlayerPrefs.GetInt("Score");
        currentScore += score;
        PlayerPrefs.SetInt("Score", currentScore);

        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            // Panggil ScoreLevelOne hanya jika berada di scene "LevelOne"
            ScoreLevelOne(currentScore);
        } 
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            ScoreLevelTwo(currentScore);
        }
        else if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            ScoreLevelThree(currentScore);
        }
        else if (SceneManager.GetActiveScene().name == "CasualOne")
        {
            ScoreCasualOne(currentScore);
        }
        else if (SceneManager.GetActiveScene().name == "CasualTwo")
        {
            ScoreCasualTwo(currentScore);
        }
        else if (SceneManager.GetActiveScene().name == "CasualThree")
        {
            ScoreCasualThree(currentScore);
        }
        else if (SceneManager.GetActiveScene().name == "CasualFour")
        {
            ScoreCasualFour(currentScore);
        }
        else if (SceneManager.GetActiveScene().name == "CasualFive")
        {
            ScoreCasualFive(currentScore);
        }
    }

    public void ScoreLevelOne(int currentScore)
    {// Periksa apakah scene saat ini adalah "LevelOne"
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            Debug.Log("Current Score: " + currentScore);

            // Mengatur aktivasi game object berdasarkan rentang nilai skor
            if (currentScore >= 1827)
            {
                SetGameObjectActive(skoreA);
            }
            else if (currentScore >= 1624)
            {
                SetGameObjectActive(skoreB);
            }
            else if (currentScore >= 1421)
            {
                SetGameObjectActive(skoreC);
            }
            else if (currentScore >= 1218)
            {
                SetGameObjectActive(skoreD);
            }
            else
            {
                SetGameObjectActive(skoreE);
            }
        }
    }

    public void ScoreLevelTwo(int currentScore)
    {// Periksa apakah scene saat ini adalah "LevelTwo"
        if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            Debug.Log("Current Score: " + currentScore);

            // Mengatur aktivasi game object berdasarkan rentang nilai skor
            if (currentScore >= 1.764)
            {
                SetGameObjectActive(skoreA);
            }
            else if (currentScore >= 1568)
            {
                SetGameObjectActive(skoreB);
            }
            else if (currentScore >= 1372)
            {
                SetGameObjectActive(skoreC);
            }
            else if (currentScore >= 1176)
            {
                SetGameObjectActive(skoreD);
            }
            else
            {
                SetGameObjectActive(skoreE);
            }
        }


    }

    public void ScoreLevelThree(int currentScore)
    {// Periksa apakah scene saat ini adalah "LevelThree"
        if (SceneManager.GetActiveScene().name == "LevelThree")
        {
            Debug.Log("Current Score: " + currentScore);

            // Mengatur aktivasi game object berdasarkan rentang nilai skor
            if (currentScore >= 3.690)
            {
                SetGameObjectActive(skoreA);
            }
            else if (currentScore >= 3280)
            {
                SetGameObjectActive(skoreB);
            }
            else if (currentScore >= 2870)
            {
                SetGameObjectActive(skoreC);
            }
            else if (currentScore >= 2460)
            {
                SetGameObjectActive(skoreD);
            }
            else
            {
                SetGameObjectActive(skoreE);
            }
        }


    }


    public void ScoreCasualOne(int currentScore)
    {// Periksa apakah scene saat ini adalah "CasualOne"
        if (SceneManager.GetActiveScene().name == "CasualOne")
        {
            Debug.Log("Current Score: " + currentScore);

            // Mengatur aktivasi game object berdasarkan rentang nilai skor
            if (currentScore >= 2358)
            {
                SetGameObjectActive(skoreA);
            }
            else if (currentScore >= 2096)
            {
                SetGameObjectActive(skoreB);
            }
            else if (currentScore >= 1834)
            {
                SetGameObjectActive(skoreC);
            }
            else if (currentScore >= 1572)
            {
                SetGameObjectActive(skoreD);
            }
            else
            {
                SetGameObjectActive(skoreE);
            }
        }


    }


    public void ScoreCasualTwo(int currentScore)
    {// Periksa apakah scene saat ini adalah "CasualTwo"
        if (SceneManager.GetActiveScene().name == "CasualTwo")
        {
            Debug.Log("Current Score: " + currentScore);

            // Mengatur aktivasi game object berdasarkan rentang nilai skor
            if (currentScore >= 5220)
            {
                SetGameObjectActive(skoreA);
            }
            else if (currentScore >= 4640)
            {
                SetGameObjectActive(skoreB);
            }
            else if (currentScore >= 4060)
            {
                SetGameObjectActive(skoreC);
            }
            else if (currentScore >= 3480)
            {
                SetGameObjectActive(skoreD);
            }
            else
            {
                SetGameObjectActive(skoreE);
            }
        }

    }

    public void ScoreCasualThree(int currentScore)
    {// Periksa apakah scene saat ini adalah "CasualThree"
        if (SceneManager.GetActiveScene().name == "CasualThree")
        {
            Debug.Log("Current Score: " + currentScore);

            // Mengatur aktivasi game object berdasarkan rentang nilai skor
            if (currentScore >= 3.690)
            {
                SetGameObjectActive(skoreA);
            }
            else if (currentScore >= 3280)
            {
                SetGameObjectActive(skoreB);
            }
            else if (currentScore >= 2870)
            {
                SetGameObjectActive(skoreC);
            }
            else if (currentScore >= 2460)
            {
                SetGameObjectActive(skoreD);
            }
            else
            {
                SetGameObjectActive(skoreE);
            }
        }
    }

    public void ScoreCasualFour(int currentScore)
    {// Periksa apakah scene saat ini adalah "CasualFour"
        if (SceneManager.GetActiveScene().name == "CasualFour")
        {
            // Mengatur aktivasi game object berdasarkan rentang nilai skor
            if (currentScore >= 1.764)
            {
                SetGameObjectActive(skoreA);
            }
            else if (currentScore >= 1568)
            {
                SetGameObjectActive(skoreB);
            }
            else if (currentScore >= 1372)
            {
                SetGameObjectActive(skoreC);
            }
            else if (currentScore >= 1176)
            {
                SetGameObjectActive(skoreD);
            }
            else
            {
                SetGameObjectActive(skoreE);
            }
        }
    }

    public void ScoreCasualFive(int currentScore)
    {// Periksa apakah scene saat ini adalah "CasualFive"
        if (SceneManager.GetActiveScene().name == "CasualFive")
        {
            Debug.Log("Current Score: " + currentScore);

            // Mengatur aktivasi game object berdasarkan rentang nilai skor
            if (currentScore >= 1827)
            {
                SetGameObjectActive(skoreA);
            }
            else if (currentScore >= 1624)
            {
                SetGameObjectActive(skoreB);
            }
            else if (currentScore >= 1421)
            {
                SetGameObjectActive(skoreC);
            }
            else if (currentScore >= 1218)
            {
                SetGameObjectActive(skoreD);
            }
            else
            {
                SetGameObjectActive(skoreE);
            }
        }
    }
    // Fungsi untuk mengatur aktivasi game object
    private void SetGameObjectActive(GameObject gameObjectToActivate)
    {
        skoreA.SetActive(false);
        skoreB.SetActive(false);
        skoreC.SetActive(false);
        skoreD.SetActive(false);
        skoreE.SetActive(false);

        gameObjectToActivate.SetActive(true);
    }

    // Fungsi untuk mengambil nilai skor saat ini
    public int GetCurrentScore()
    {
        return PlayerPrefs.GetInt("Score");
    }
}


 


