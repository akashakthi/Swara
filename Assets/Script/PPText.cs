using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPText : MonoBehaviour
{
    public string name;
    public string perfectName;
    public string goodName;
    public string badName;

    Text textComponent;
    // Update is called once per frame

    private void Start()
    {
        textComponent = GetComponent<Text>();
    }
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(name)+"";

    }
}
