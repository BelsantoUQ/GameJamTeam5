
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameHasEnded = true;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject Score;


    private void Update()
    {
        EndGame();
    }


    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        
        Score.SetActive(false);

    }


}
