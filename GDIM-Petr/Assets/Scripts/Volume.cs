using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider = null;

    private string nam = "BG Music";
    
    public void OnOff(bool pause)
    {
        AudioManager.instance.Pause(nam, pause);
    }

    public void VolumeLevel(float num)
    {
        num = volumeSlider.value;
        AudioManager.instance.Volume(nam, num);
    }

}
