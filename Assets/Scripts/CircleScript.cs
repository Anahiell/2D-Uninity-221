using UnityEngine;

public class CircleScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed = 5f;

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();    
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * 500);
        }
        float moveInput = Input.GetAxis("Horizontal"); 
        rb2d.linearVelocity = new Vector2(moveInput * moveSpeed, rb2d.linearVelocity.y); 

    }
}
