using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderBootstrap : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] //scene�� �ε�Ǳ��� �޼��带 �����ض� ��׿�
    
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
