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
    private GameObject box;
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private CapsuleCollider2D col;
    [SerializeField]
    private float dialogueCD;

    private void Start() 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            StartCoroutine(DelayBox());
            RandomizeDialogue();
        }
    }


    private void RandomizeDialogue()
    {
        int index = Random.Range(0, dialogue.Length);
        text.text = dialogue[index];
    }

    IEnumerator DelayBox()
    {
        box.SetActive(true);
        col.enabled = false;
        yield return new WaitForSeconds(dialogueCD);
        col.enabled = true;
        box.SetActive(false);
    }
}
