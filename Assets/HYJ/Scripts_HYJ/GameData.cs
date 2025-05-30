using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentLevel;                   // 현재 진행 중인 레벨
    public List<bool> puzzleCleared;           // 각 퍼즐의 클리어 여부 리스트
    public PlayerData playerData;              // 플레이어의 상태 정보
}