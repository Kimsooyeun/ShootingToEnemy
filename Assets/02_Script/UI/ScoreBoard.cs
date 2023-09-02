using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    float currentscore = 0;
    int nowScore = 0; 
    TextMeshProUGUI score;

    PlayerController player;
    public float minScoreUpSpeed = 50.0f;
    private void Awake()
    {
        Transform child = transform.GetChild(1);
        score = child.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        player.onScoreChange += ScoreUpdate;
        score.text = currentscore.ToString();
    }

    private void Update()
    {
        if(currentscore < nowScore) 
        {
            float speed = Mathf.Max((nowScore - currentscore) * 5.0f, minScoreUpSpeed);
            currentscore += Time.deltaTime * speed;

            currentscore = Mathf.Min(currentscore, nowScore);
            score.text = $"{currentscore:f0}";
        }
    }

    private void ScoreUpdate(int newScore)
    {

        Debug.Log("점수증가");
        nowScore = newScore;
    }
}
