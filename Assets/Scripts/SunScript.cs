using UnityEngine;

public class SunScript : MonoBehaviour
{
    public float swayAmount = 0.2f; // амплитуда качания
    public float swaySpeed = 1f;    // скорость качания
    public float rotationSpeed = 20f; // скорость вращения
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // запоминаем начальную позицию
    }

    void Update()
    {
        // Качание по оси Y
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.position = initialPosition + new Vector3(sway, sway, 0);

        // Лёгкое вращение туда-сюда
        float rotation = Mathf.Sin(Time.time * swaySpeed) * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
