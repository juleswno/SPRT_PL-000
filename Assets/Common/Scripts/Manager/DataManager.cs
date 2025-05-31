using System.Collections.Generic;
using UnityEngine;

// 데이터 상태를 관리
public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public int currentLevel;
    public List<bool> puzzleCleared;
    public PlayerData playerData;

    private void Awake()
    {
        // 싱글톤 인스턴스 초기화
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 바뀌어도 유지됨
    }

    // 게임 저장
    public void Save()
    {
        GameData data = new GameData()
        {
            currentLevel = this.currentLevel,
            puzzleCleared = this.puzzleCleared,
            playerData = this.playerData
        };

        SaveManager.Save(data);
    }

    // 저장된 게임 불러오기
    public void Load()
    {
        GameData data = SaveManager.Load();
        if (data != null)
        {
            this.currentLevel = data.currentLevel;
            this.puzzleCleared = data.puzzleCleared;
            this.playerData = data.playerData;
        }
    }
}