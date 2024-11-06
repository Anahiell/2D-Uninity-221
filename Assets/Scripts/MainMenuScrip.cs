using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScrip : MonoBehaviour
{
    public AudioSource startSound;         
    public Image fadePanel; 
    public TextMeshProUGUI fadeText;
    public float fadeDuration = 1.0f;       
    public float startDelay = 0.5f;

    private void Start()
    {
        Time.timeScale = 1.0f;
        if (fadePanel != null)
        {
            fadePanel.gameObject.SetActive(false);
            Color panelColor = fadePanel.color;
            panelColor.a = 0f;
            fadePanel.color = panelColor;
        }
        if (fadeText != null)
        {
            Color textColor = fadeText.color;
            textColor.a = 0f;
            fadeText.color = textColor;
        }
    }

    public void StartGame()
    {
        AudioManager.Instance.PlayStartSound(startSound);
        StartCoroutine(StartGameWithDelay());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator StartGameWithDelay()
    {
        // Включаем панель перед началом анимации
        if (fadePanel != null)
        {
            fadePanel.gameObject.SetActive(true);
        }

        if (startSound != null)
        {
            startSound.Play();
        }

        if (fadePanel != null && fadeText != null)
        {
            float elapsedTime = 0f;

            Color panelColor = fadePanel.color;
            Color textColor = fadeText.color;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);

                panelColor.a = alpha;
                fadePanel.color = panelColor;

                textColor.a = alpha;
                fadeText.color = textColor;

                yield return null;
            }
        }

        yield return new WaitForSeconds(startDelay);

        SceneManager.LoadScene("SampleScene");

    }
}
