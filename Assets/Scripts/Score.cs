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
    private bool _activeScore;
    private void Awake()
    {
        points.score = 0;
        _activeScore = true;
    }

    private void FixedUpdate()
    {
        if (!_activeScore) return;
        points.score += Time.deltaTime * 5;
        scoreText.text = points.score.ToString("0");
    }

    public void SetScoreActive(bool active)
    {
        _activeScore = active;
    }
    
    public void AddPoints()
    {
        points.score += 100;
    }
    
    public void AddBonusPoints()
    {
        points.score += 500;
    }
}
