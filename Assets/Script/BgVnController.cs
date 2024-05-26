using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgVnController : MonoBehaviour
{

    public bool isSwitched = false;
    public Image bgAdri;
    public Image bgMaya;
    // Start is called before the first frame update
   public void SwictchImage(Sprite sprite)
    {
        if(!isSwitched)
        {
            bgAdri.sprite = sprite;
        }
        else
        {
            bgMaya.sprite = sprite;
        }
        isSwitched = !isSwitched;
    }
    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            bgMaya.sprite = sprite;
        }
        else
        {
            bgAdri.sprite = sprite;
        }
    }
   
}
