using UnityEngine;


[CreateAssetMenu(fileName = "MazePatternData", menuName = "Maze/NewPattern")]
public class MazePatternData : ScriptableObject
{
    [Header("�̷� ���� ����")]
    public int mazeId;
    public GameObject mazePatternPrefab;
    public string description;
    
    [Header("�÷��̾� ���� & �ⱸ ��ġ")]
    public Vector3 startPos;
    public Vector3 endPos;
}
