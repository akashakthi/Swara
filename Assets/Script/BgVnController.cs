using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgVnController : MonoBehaviour
{

    public bool isSwitched = false;
    public Image bgVn;
    public Image bgAdri;
    // Start is called before the first frame update
   public void SwictchImage(Sprite sprite)
    {
        if(!isSwitched)
        {
            bgAdri.sprite = sprite;
        }
        else
        {
            bgVn.sprite = sprite;
        }
        isSwitched = !isSwitched;
    }
    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            bgVn.sprite = sprite;
        }
        else
        {
            bgAdri.sprite = sprite;
        }
    }
   
}
