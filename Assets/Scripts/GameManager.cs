using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;

    public static int currentLevel;
    public static int noOfPassingRings;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelCompletePanel;

    private void Start()
    {
        Time.timeScale = 1.0f;
        gameOver = false;
        levelComplete = false;
    }

    private void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
        
        if (levelComplete)
        {
            
            levelCompletePanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
