using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class ScoreBoard : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private int scorePerHit = 15;
    private Text scoreText;


    // Start is called before the first frame update
    void Update()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit()
    {
        score += scorePerHit;
    }
}
