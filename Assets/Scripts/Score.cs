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

    private void Awake()
    {
        points.score = 0;
    }

    private void FixedUpdate()
    {
        points.score += Time.deltaTime * 10;
        scoreText.text = points.score.ToString("0");
    }


    public void addPoints()
    {
        points.score += 100;
    }


}
