
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameHasEnded = true;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private RectTransform score;


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
        score.Translate(new Vector3(-330f, 180f, 0f));
        gameOver.SetActive(true);
        
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}
