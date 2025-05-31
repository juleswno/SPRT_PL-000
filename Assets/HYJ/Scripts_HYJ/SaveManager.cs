using System.IO;
using UnityEngine;

// 저장 & 불러오기
public static class SaveManager
{
    private static string savePath = Application.persistentDataPath + "/save.json"; // 플랫폼별 저장 경로

    // 저장
    public static void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, true); // true: 보기 편하게 들여쓰기 포함
        File.WriteAllText(savePath, json);
    }

    // 불러오기
    public static GameData Load()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("저장 파일이 존재하지 않음");
            return null;
        }

        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<GameData>(json);
    }
}