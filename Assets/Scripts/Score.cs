using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Variable para poder saber la colision con los puntos
    public float score = 0;
    public TextMeshProUGUI scoreText;


    private void FixedUpdate()
    {
        score += Time.deltaTime * 10;
        scoreText.text = score.ToString("0");
    }


    public void addPoints()
    {
        score += 100;
    }


}
