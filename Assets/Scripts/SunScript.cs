using UnityEngine;

public class SunScript : MonoBehaviour
{
    public float swayAmount = 0.2f; // ��������� �������
    public float swaySpeed = 1f;    // �������� �������
    public float rotationSpeed = 20f; // �������� ��������
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // ���������� ��������� �������
    }

    void Update()
    {
        // ������� �� ��� Y
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.position = initialPosition + new Vector3(sway, sway, 0);

        // ˸���� �������� ����-����
        float rotation = Mathf.Sin(Time.time * swaySpeed) * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
