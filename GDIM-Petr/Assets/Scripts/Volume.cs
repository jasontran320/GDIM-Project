using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider = null;
    private bool pause = false;
    private string nam = "BG Music";
 
    public void Pause()
    {
        if(pause)
        {
            pause = false;
        }else
        {
            pause = true;
        }
        AudioManager.instance.Pause(nam, pause);
    }


    public void VolumeLevel(float num)
    {
        num = volumeSlider.value;
        AudioManager.instance.Volume(nam, num);
    }

}
