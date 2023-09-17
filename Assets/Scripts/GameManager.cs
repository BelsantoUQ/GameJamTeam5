
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
    private ShieldBar shieldController;


    void Start()
    {
        scoreController = FindObjectOfType<Score>();
        shieldController = FindObjectOfType<ShieldBar>();
        shieldController.RemoveShield();
    }

    private void Update()
    {
        EndGame();
    }

    public void AddBonusPoints()
    {
        scoreController.AddBonusPoints();
    }
    
    public void AddPoints()
    {
        scoreController.AddPoints();
    }

    public void AddShield()
    {
        shieldController.AddShield();
    }
    
    public void RemoveShield()
    {
        shieldController.RemoveShield();
    }
    
    
    
    public bool IsShieldReady()
    {
        return shieldController.IsShieldReady();
    }

    public void EndGame()
    {
        if (gameHasEnded != false) return;
        gameHasEnded = true;
        GameOver();
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
