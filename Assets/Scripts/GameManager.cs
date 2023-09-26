using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelComplete;

    public static int currentLevel;
    public static int noOfPassingRings;

    [SerializeField] TextMeshProUGUI currentLevelTxt;
    [SerializeField] TextMeshProUGUI nextLevelTxt;

    [SerializeField] Slider levelBar;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelCompletePanel;

    Color32 levelColor;

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel",1);
        levelColor = new Color(Random.Range(0f, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
    }

    private void Start()
    {

        Time.timeScale = 1.0f;
        gameOver = false;
        levelComplete = false;
        
        
        
        Camera.main.backgroundColor = levelColor;

        noOfPassingRings = 0;

        currentLevelTxt.text=currentLevel.ToString();
        nextLevelTxt.text=(currentLevel+1).ToString();
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

        int lvlBar = noOfPassingRings * 100 / FindObjectOfType<HelixManager>().noOfRings;
        levelBar.value = lvlBar;
        
        if (levelComplete)
        {
            
            levelCompletePanel.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
