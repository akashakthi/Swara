using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CartoonFX.CFXR_Effect;

public class SkorAkhir : MonoBehaviour
{
    public Text totalPerfect;
    public Text totalGood;
    public Text totalBad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            float relativePosition = Mathf.Abs(transform.position.y - col.transform.position.y) / (GetComponent<BoxCollider2D>().size.y / 2);
           
            int perfectToAdd = 0;
            int goodToAdd = 0;
            int badToAdd = 0;
            

            if (relativePosition >= 0.81f)
            {
                
                perfectToAdd = 1;
                
              
                totalPerfect.text = (int.Parse(totalPerfect.text) + 1).ToString();
            }
            else if (relativePosition >= 0.66f)
            {
             
                goodToAdd = 1;
             
               
                totalGood.text = (int.Parse(totalGood.text) + 1).ToString();
            }
            else
            {
                badToAdd = 1;
             
               
                totalBad.text = (int.Parse(totalBad.text) + 1).ToString();
            }

       ;
            AddTotalPerfect(perfectToAdd);
            AddTotalGood(goodToAdd);
            AddTotalBad(badToAdd);
           
          
        }
    }
   

    void AddTotalPerfect(int totalPerfect)
    {
        int currentTotalPerfect = PlayerPrefs.GetInt("totalPerfect");
        totalPerfect += totalPerfect;
        PlayerPrefs.SetInt("Perfect", totalPerfect);
    }
    void AddTotalGood(int totalGood)
    {
        int currentTotalPerfect = PlayerPrefs.GetInt("totalPerfect");
        totalGood += totalGood;
        PlayerPrefs.SetInt("Perfect", totalGood);
    }
    void AddTotalBad(int totalBad)
    {
        int currentTotalPerfect = PlayerPrefs.GetInt("totalPerfect");
        totalBad += totalBad;
        PlayerPrefs.SetInt("Perfect", totalBad);
    }
}
