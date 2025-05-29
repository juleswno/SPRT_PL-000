using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ballPrefab;       // 생성할 공 프리팹
    public int numberOfBalls = 10;       // 생성할 공 개수
    public Vector3 startPosition = Vector3.zero;  // 시작 위치
    public float spacing = 2.0f;        // 공 간의 간격

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

