using UnityEngine;

public class TutorialButtonGroup : MonoBehaviour
{
    private void Update()
    {
        // Проверяем нажатие клавиш
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Transform btn = transform.Find("TutorialButtonLeft");
            if (btn != null)
            {
                btn.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Transform btn = transform.Find("TutorialButtonRight");
            if (btn != null)
            {
                btn.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform btn = transform.Find("TutorialButtonSpace");
            if (btn != null)
            {
                btn.gameObject.SetActive(false);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            Transform btn = transform.Find("TutorialButtonEsc");
            if (btn != null)
            {
                btn.gameObject.SetActive(false);
            }
        }
        CheckAndDestroyParent();
    }
    private void CheckAndDestroyParent()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf) 
            {
                return; 
            }
        }

        Destroy(gameObject);
    }

}
