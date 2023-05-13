using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private string[] dialogue;
    [SerializeField]
    private SpriteRenderer box;
    [SerializeField]
    private TMP_Text text;

    private void Start() 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            

        }
    }

    private void RandomizeDialogue()
    {
        int index = Random.Range(0, dialogue.Length);
        
    }
}
