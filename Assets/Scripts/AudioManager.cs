using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void PlayStartSound(AudioSource startSound)
    {
        if (startSound != null && !startSound.isPlaying)
        {
            startSound.Play();
        }
    }
}
