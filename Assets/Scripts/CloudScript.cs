using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f ;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime*Vector3.left);
    }
}
