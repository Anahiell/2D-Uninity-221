using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    
    [SerializeField]
    public GameObject[] objectsToSpawn; //prefab of object wich created
    public float[] spawnIntervals;
    void Start()
    {
        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            int index = i; 
            InvokeRepeating("SpawnObject" + i, spawnIntervals[i], spawnIntervals[i]);
        }

    }
    private void SpawnObject0() => SpawnObject(0);
    private void SpawnObject1() => SpawnObject(1);
    private void SpawnObject2() => SpawnObject(2);
    private void SpawnObject(int index)
    {
        GameObject selectedObject = objectsToSpawn[index];

        Vector3 spawnPosition;

        if (index == 2 || index == 1) 
        {
            // �������� ������ ������
            float cameraHeight = Camera.main.orthographicSize * 2;
            // ��������� ������� ������ � ������� ����� ������ (1/3 �� ������)
            float randomOffset = Random.Range(-0.5f, 0.5f); //  ����� �� Y
            spawnPosition = new Vector3(transform.position.x, (cameraHeight / 3) + randomOffset, 0);
        }
        else //  �����
        {
            spawnPosition = new Vector3(transform.position.x, Random.Range(-2f, 2f), 0);
        }

        Instantiate(selectedObject, spawnPosition, Quaternion.identity);
    }
}
