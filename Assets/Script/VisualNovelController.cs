using UnityEngine;
using UnityEngine.SceneManagement;

public class VisualNovelController : MonoBehaviour
{
    public StoryScene currentScene;
    public NaratorBox naratorBox;
    public BgVnController bgVnController;

    private float lastSpaceTime;
    public float doubleSpaceThreshold = 0.5f; // Adjust this threshold as needed

    // Start is called before the first frame update
    void Start()
    {
        naratorBox.PlayScene(currentScene);
        bgVnController.SetImage(currentScene.background);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (naratorBox.IsCompleted())
            {
                if (naratorBox.IsLastSentence())
                {
                    if (currentScene.nextScene != null)
                    {
                        currentScene = currentScene.nextScene;
                        naratorBox.PlayScene(currentScene);
                        bgVnController.SwictchImage(currentScene.background);
                    }
                    else
                    {
                        LoadNextLevel();
                    }
                }
                else
                {
                    naratorBox.PlayNextSentences();
                }
            }
        }

        // Check for double space press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSpaceTime < doubleSpaceThreshold)
            {
                naratorBox.CompleteText();
            }
            lastSpaceTime = Time.time;
        }
    }

    void LoadNextLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string loadingSceneName = "";

        // Determine which loading scene to load based on the current scene
        switch (sceneName)
        {
            case "VisualOne":
                loadingSceneName = "LoadingOne";
                break;
            case "VisualTwo":
                loadingSceneName = "LoadingTwo";
                break;
            case "VisualThree":
                loadingSceneName = "LoadingThree";
                break;
            case "VisualOneEnd":
                loadingSceneName = "SelectStory";
                break;
            case "VisualTwoEnd":
                loadingSceneName = "SelectStory";
                break;
            case "VisualThreeEndHappy":
                loadingSceneName = "MainMenu";
                break;
            case "VisualThreeEndSad":
                loadingSceneName = "LoadingThree";
                break;

            // Add more cases as needed for additional scenes
            default:
                // If the current scene is not one of the specified scenes, just load the default loading scene
                loadingSceneName = "DefaultLoadingScene";
                break;
        }

        SceneManager.LoadScene(loadingSceneName);
  
    }

    
}
