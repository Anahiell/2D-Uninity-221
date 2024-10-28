using UnityEngine;

public class DestroyerScrip : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.name);
        Transform parent = other.transform.parent;
        if (parent != null)
        {
            Destroy(parent.gameObject);
        }
        else { 
        Destroy(other.gameObject);
        }
        
    }
}
