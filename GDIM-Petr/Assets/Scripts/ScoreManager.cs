using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TimerTxt, ScoreTxt;
    [SerializeField]
    private Canvas endScreen;
    public int enemiesKilled;
    private bool timerGoing;
    private float timeElapsed;
    public static string scoreStr;

    private void Awake() 
    {
        timeElapsed = 0f;
        timerGoing = false;
    }

    private void Start()
    {
        StartTimer();
        endScreen.enabled = false;
    }

    private void StartTimer()
    {
        timeElapsed = 0f;
        timerGoing = true;
        StartCoroutine(UpdateTimer());
    }

    private void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            timeElapsed += Time.deltaTime;
            string timeStr = timeElapsed.ToString("#.##");
            TimerTxt.text = timeStr;

            yield return null;
        }
    }

    private void CalculateScore()
    {
        float score = 10000 - timeElapsed - enemiesKilled;
        scoreStr = "Score: " + score.ToString("#");
        TimerTxt.text = null;
        ScoreTxt.text = scoreStr;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            EndTimer();
            CalculateScore();
        }
    }

    private void EndScreen()
    {
        endScreen.enabled = true;
    }
}