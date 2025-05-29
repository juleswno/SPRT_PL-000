using UnityEngine;


[CreateAssetMenu(fileName = "MazePatternData", menuName = "Maze/NewPattern")]
public class MazePatternData : ScriptableObject
{
    [Header("미로 패턴 정보")]
    public int mazeId;
    public GameObject mazePatternPrefab;
    public string description;
    
    [Header("플레이어 시작 & 출구 위치")]
    public Vector3 startPos;
    public Vector3 endPos;
}
