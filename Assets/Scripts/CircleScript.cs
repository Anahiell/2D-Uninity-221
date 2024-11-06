using UnityEngine;

public class CircleScript : MonoBehaviour
{
    [SerializeField]
    private float forceFactor = 400f;

    private PauseScript pauseScript;

    public static int score;

    private Rigidbody2D rb2d;

    public float moveSpeed = 5f;

    private AudioSource jumpSound;

    void Start()
    {

        rb2d = this.GetComponent<Rigidbody2D>();
        jumpSound = GetComponent<AudioSource>();
        score = 0;
        GameObject pauseCanvas = GameObject.Find("PauseCanvas");
        if (pauseCanvas != null)
        {
            pauseScript = pauseCanvas.GetComponent<PauseScript>();
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(forceFactor * Time.timeScale * Vector2.up);
            jumpSound.Play();
        }
        float moveInput = Input.GetAxis("Horizontal"); 
        rb2d.linearVelocity = new Vector2(moveInput * moveSpeed, rb2d.linearVelocity.y); 

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Faoult"))
        {
            if(pauseScript != null)
            {
                pauseScript.ShowGameOverMenu(score);
            }
            else
            {
                Debug.LogError("PauseCanvas not found");
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Tube"))
        {
            //Debug.Log("+1");
            score += 1;
        }
    }
}
