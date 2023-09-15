
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameHasEnded = true;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject backScore;
    [SerializeField] private GameObject HudScore;
    private Score scoreController;


    void Start()
    {
        scoreController = FindObjectOfType<Score>();
    }

    private void Update()
    {
        EndGame();
    }

    public void addPoints()
    {
        scoreController.addPoints();
    }

    public void addShield()
    {
        scoreController.addShield();
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
        backScore.SetActive(false);
        HudScore.SetActive(false);
        gameOver.SetActive(true);
        scoreController.SetScoreActive(false);
    }

}
