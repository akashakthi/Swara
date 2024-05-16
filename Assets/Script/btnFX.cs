using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFX;
    public AudioClip pressedFX;
    // Start is called before the first frame update

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFX);
    }

    public void PressedSound()
    {
        myFx.PlayOneShot(pressedFX);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
