using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TMP_Text scoreText;
    public GameObject gameOverScreen;
    public static bool gameIsOver = false;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameIsOver)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }

    public void restartGame()
    {
        gameIsOver = false;

        BoostPowerUpScript.StopBoost();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (gameIsOver) return;

        gameIsOver = true;
        gameOverScreen.SetActive(true);
        AudioManager.instance.PlayGameOverSound();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
