using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private bool isChecked;

    private void Awake() 
    {
        isChecked = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(isChecked)
        {
            this.tag = "Untagged";
        }else
        {
            this.tag = "Checkpoint";
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            isChecked = true;
        }
    }
}
