using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScore : MonoBehaviour
{
    //Variable para poder saber la colision con los puntos
    [SerializeField] HudVariables points;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = points.score.ToString("0");
    }

}
