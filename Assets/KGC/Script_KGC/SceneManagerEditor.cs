
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SceneLoadManager))]

public class SceneManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        SceneLoadManager sceneManager = (SceneLoadManager)target;

        if (GUILayout.Button("�� �̸� ���"))
        {
            sceneManager.AutoAssignScenePaths();
        }
    }
}
