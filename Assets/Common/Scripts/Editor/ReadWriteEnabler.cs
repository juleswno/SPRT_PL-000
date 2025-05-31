#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;

public class ReadWriteEnabler : EditorWindow
{
    [MenuItem("Tools/Enable Read/Write On All Meshes")]
    public static void EnableReadWrite()
    {
        string[] modelGuids = AssetDatabase.FindAssets("t:Model", new[] { "Assets" });
        int changedCount = 0;

        foreach (string guid in modelGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ModelImporter importer = AssetImporter.GetAtPath(path) as ModelImporter;

            if (importer != null && !importer.isReadable)
            {
                importer.isReadable = true;
                EditorUtility.SetDirty(importer);
                importer.SaveAndReimport();
                changedCount++;
                Debug.Log($"✔ Read/Write Enabled: {path}");
            }
        }

        Debug.Log($"🔁 전체 완료 - 변경된 모델 수: {changedCount}");
    }
}
#endif