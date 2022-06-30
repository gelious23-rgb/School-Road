using UnityEngine;

public class GameOver : Startgame
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    private void Start() => 
        gameOver = false;

    private void Update()
    {
        if (!gameOver)
        {
            Time.timeScale = 1;
            return;
        }
        else
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            
        }
    }
}
