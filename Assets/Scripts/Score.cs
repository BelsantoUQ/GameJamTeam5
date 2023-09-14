using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Variable para poder saber la colision con los puntos
    [SerializeField] HudVariables points;
    public TextMeshProUGUI scoreText;
    private bool activeScore;
    private void Awake()
    {
        points.score = 0;
        activeScore = true;
    }

    private void FixedUpdate()
    {
        if (activeScore)
        {
            points.score += Time.deltaTime * 10;
            scoreText.text = points.score.ToString("0");
        }
    }

    public void SetScoreActive(bool active)
    {
        activeScore = active;
    }
    
    public void addPoints()
    {
        points.score += 100;
    }

    public void addShield()
    {
        if(points.shield <99)
            points.shield += 25;
    }
}
