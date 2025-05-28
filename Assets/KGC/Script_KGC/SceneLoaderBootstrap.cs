using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderBootstrap : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] //scene이 로드되기전 메서드를 실행해라 라네용
    
    private static void Init()
    {
        string path = "Common/Prefabs/SceneManager";
        GameObject sceneLoader= UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/"+path+".prefab");
        
        
        if (sceneLoader != null)
        {
            GameObject loader= GameObject.Instantiate(sceneLoader);
            loader.name = "SceneManager";
        }
        else
        {
            Debug.Log("not found SceneManagerPrefab");
        }
    }
    
}
