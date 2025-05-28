using UnityEngine;

public class MazeManager : MonoBehaviour
{
   [SerializeField] private MazePatternData[] mazeData;
   
   private GameObject curMaze;

   public void SpawnRandomMaze()
   {
      int random = Random.Range(0, mazeData.Length);
      
      MazePatternData selected = mazeData[random];

      if (selected.mazePatternPrefab != null)
      {
         curMaze = Instantiate(selected.mazePatternPrefab,Vector3.zero, Quaternion.identity);
      }
   }
}
