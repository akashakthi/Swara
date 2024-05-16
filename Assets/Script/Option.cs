using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public void backMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }

   
}
