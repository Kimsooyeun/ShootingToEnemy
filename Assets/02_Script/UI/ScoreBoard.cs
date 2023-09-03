using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    float currentscore = 0;
    TextMeshProUGUI textScore;
    public int score = 0;
    public float minScoreUpSpeed = 50.0f;
    private void Awake()
    {
        Transform child = transform.GetChild(1);
        textScore = child.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        textScore.text = currentscore.ToString();
    }

    private void Update()
    {
        Debug.Log("score " + score + ", cur " + currentscore);

        //abcd += 1;
        if (currentscore < score) 
        {
            float speed = Mathf.Max((score - currentscore) * 5.0f, minScoreUpSpeed);
            currentscore = Mathf.Min(currentscore, score);
            currentscore += Time.deltaTime * speed;

            textScore.text = $"{currentscore:f0}";

            //Debug.Log(score);
        }
    }

    public void AddScore(int plus)
    {
        score += plus;
    }
}
