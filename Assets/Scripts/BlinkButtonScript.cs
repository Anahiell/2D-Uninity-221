using UnityEngine;

public class BlinkButtonScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] 
    private Color flashColor = Color.red;
    public Color normalColor = Color.white;
    [SerializeField]
    public float flashSpeed = 0.5f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(FlashButton());
    }

    private System.Collections.IEnumerator FlashButton()
    {
        while (true)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashSpeed);
            spriteRenderer.color = normalColor;
            yield return new WaitForSeconds(flashSpeed);
        }
    }
}
