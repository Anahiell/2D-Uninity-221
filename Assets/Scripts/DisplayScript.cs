using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    //[SerializeField]
    private TMPro.TextMeshProUGUI scoreText;
    //[SerializeField]
    private TMPro.TextMeshProUGUI timeText;

    private float gameTime;

    private int previosScore = 0;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
        timeText = GameObject.Find("TimeText").GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0f;
        timeText.enableVertexGradient = true;
        timeText.colorGradient = new TMPro.VertexGradient(Color.red, Color.yellow, Color.green, Color.blue);
        //anchor
        timeText.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        timeText.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        timeText.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
    }

    void Update()
    {
        //time score
        gameTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(gameTime / 60F);
        int seconds = Mathf.FloorToInt(gameTime % 60F);
        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        //animation of shaking(by z)
        float shakeOffset = Mathf.Sin(Time.time * 2f) * 15f;
        timeText.transform.localRotation = Quaternion.Euler(0,0,shakeOffset);
        float progress = Mathf.Clamp01(gameTime / 300f); 
        Color startColor = Color.green;
        Color endColor = Color.red;
        Color interpolatedColor = Color.Lerp(startColor, endColor, progress);

        timeText.colorGradient = new TMPro.VertexGradient(interpolatedColor, interpolatedColor, interpolatedColor, interpolatedColor);
        
        float scale = Mathf.Lerp(1f, 3f, progress); 
        timeText.transform.localScale = new Vector3(scale, scale, scale);
        //simple score
        if (CircleScript.score != previosScore)
        {
            StartCoroutine(ShakeText(scoreText, Mathf.Min(CircleScript.score * 0.5f, 2f)));
            previosScore = CircleScript.score;
        }
        scoreText.text = CircleScript.score.ToString();
    }
    IEnumerator ShakeText(TMPro.TextMeshProUGUI text, float intensity)
    {
        Vector3 originalPosition = text.transform.localPosition;
        float shakeIntensity = intensity * Mathf.Clamp(CircleScript.score * 0.1f, 1f, 5f); // Увеличиваем интенсивность пропорционально счёту

        for (int i = 0; i < 10; i++)
        {
            text.transform.localPosition = originalPosition + (Vector3)Random.insideUnitCircle * shakeIntensity;
            yield return new WaitForSeconds(0.02f);
        }
        //brain boom -_-
        text.transform.localPosition = originalPosition;
    }
}
