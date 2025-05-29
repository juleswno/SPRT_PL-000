using System;
using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeManager : MonoBehaviour
{
   [SerializeField] private MazePatternData[] mazeData;
   
   [Header("NavMesh 베이크를 위한 Surface")]
   [SerializeField] private NavMeshSurface navMeshSurface;
   
   private GameObject curMaze;

   private void Start()
   {
      StartCoroutine(SpawnRandomMazeAndBake());
   }

   private IEnumerator SpawnRandomMazeAndBake()
   {

      if (curMaze != null)
      {
         Destroy(curMaze);
      }
      
      int random = Random.Range(0, mazeData.Length);
      
      MazePatternData selected = mazeData[random];

      if (selected.mazePatternPrefab != null)
      {
         curMaze = Instantiate(selected.mazePatternPrefab,Vector3.zero, Quaternion.identity);
      }
      yield return null;

      if(navMeshSurface != null)
      {
         navMeshSurface.BuildNavMesh();
      }
      else
      {
         Debug.Log("no nav mesh");
      }
         
      
   }
}
