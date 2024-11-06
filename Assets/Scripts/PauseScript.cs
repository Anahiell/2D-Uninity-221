using System.Drawing;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageText;
    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject exitButton;

    private float startTime;
    private TMPro.TextMeshProUGUI timeScoreText;
    private int tubeCount = 0; // для подсчета пройденных труб
    private const float tubeSpeed = 1.0f;

    private bool isGameOver = false;
    void Start()
    {
        GameObject timeScoreObject = GameObject.FindGameObjectWithTag("TimeScore");
        if (timeScoreObject != null)
        {
            timeScoreText = timeScoreObject.GetComponent<TextMeshProUGUI>();
            startTime = Time.time;
        }
        else
        {
            Debug.LogError("TimeScore object with tag 'timescore' not found");
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !isGameOver)
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;
            content.SetActive(!content.activeInHierarchy);

        }
        if (timeScoreText != null && !isGameOver)
        {
            float elapsedTime = Time.time - startTime;
            timeScoreText.text = $"Time: {Mathf.Round(elapsedTime)}";
        }

    }
    public void ShowPauseMenu()
    {
        isGameOver = false;
        messageText.text = "PAUSE";
        resumeButton.SetActive(true);
        exitButton.SetActive(false);
        Time.timeScale = 0;
        content.SetActive(true);
    }
    public void ShowGameOverMenu(int score)
    {
        isGameOver = true;
        float elapsedTime = Time.time - startTime;
        float distanceTraveled = tubeSpeed * elapsedTime;

        string egg = "YOU CAN BETTER";
        if (distanceTraveled > 150)
        {
            egg = "<color=#FF0000>CHETER!!!!</color>";
        }
        else if (distanceTraveled > 50)
        {
            egg = "<color=#FFD700>Sunshine look to you with pleasure</color>";
        }
        else if (distanceTraveled > 20)
        {
            egg = "<color=#00FF00>Not bad, keep going!</color>";
        }
        string finalMessage = $"GAME OVER\n" +
            $"SCORE: {score}\n" +
            $"TIME: {Mathf.Round(elapsedTime)}\n" +
            $"DISTANCE: {distanceTraveled}METERS\n" +
            $"{egg}";


        if (tubeCount > 100)
        {
            finalMessage += "Солнышко тобой не разочаровано!";
        }

        messageText.text = finalMessage;

        // Настройки для Game Over
        resumeButton.SetActive(false);
        exitButton.SetActive(true);
        Time.timeScale = 0;
        content.SetActive(true);
    }
    public void OnResumeClick()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
    }
    public void OnRestartClick()
    {
        isGameOver = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnExitClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
    private void TogglePause()
    {
        if (content.activeInHierarchy)
        {
            Time.timeScale = 1.0f;
            content.SetActive(false);
        }
        else
        {
            ShowPauseMenu();
        }
    }
}
