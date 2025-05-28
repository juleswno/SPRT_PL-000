using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager instance {get; private set;}

    [Tooltip("Scene이름 등록"),Header("씬 이름 순서대로 등록")]
    
   [SerializeField]
    private List<string> scenePathList= new List<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

#if UNITY_EDITOR
    public void AutoAssignScenePaths()
    {
        scenePathList.Clear();
        
        string[] scenePaths= AssetDatabase.FindAssets("t:Scene",new[] {"Assets/Scenes"} );

        foreach (string scenePath in scenePaths)
        {
            string path = AssetDatabase.GUIDToAssetPath(scenePath);

            if (!scenePathList.Contains(path))
            {
                scenePathList.Add(path);
            }
        }
        EditorUtility.SetDirty(this);
       
    }
    #endif

    public void LoadSceneByIndex(int _index)
    {
        if(_index<0||_index>=scenePathList.Count) return;
        
        string sceneName = scenePathList[_index];

        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        string curScene= SceneManager.GetActiveScene().name;
        int index = scenePathList.IndexOf(curScene);

        if (index >= 0 && index < scenePathList.Count - 1)
        {
            LoadSceneByIndex(index + 1);
        }
        else
        {
            Debug.Log("마지막 씬입니다.");
        }
    }
}
