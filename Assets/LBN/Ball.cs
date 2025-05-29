using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ballPrefab;       // ������ �� ������
    public int numberOfBalls = 10;       // ������ �� ����
    public Vector3 startPosition = Vector3.zero;  // ���� ��ġ
    public float spacing = 2.0f;        // �� ���� ����

    void Start()
    {
        SpawnBalls();
    }

    void SpawnBalls()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            Vector3 spawnPosition = startPosition + new Vector3(i * spacing, 0f, 0f);
            Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

