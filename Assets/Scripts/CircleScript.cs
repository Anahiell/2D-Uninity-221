using UnityEngine;

public class CircleScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

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
    }
}
