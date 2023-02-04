using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ
{
    public class ObstacleManager : MonoBehaviour
    {
        public Tile[] tiles;
        public int[] obstacleTypeArray;
        public GameObject waterPrefab;
        public GameObject rockPrefab;
        public GameObject mineralPrefab;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < obstacleTypeArray.Length; i++)
            {
                switch (obstacleTypeArray[i])
                {
                    case 1:
                        {
                            GameObject waterGO = Instantiate(waterPrefab, tiles[i].transform);
                            tiles[i].childObstacleType = obstacleTypeArray[i];
                            tiles[i].childObstacle = waterGO.GetComponent<Obstacle>();
                        }
                        break;
                    case 2:
                        {
                            GameObject rockGO = Instantiate(rockPrefab, tiles[i].transform);
                            tiles[i].childObstacleType = obstacleTypeArray[i];
                            tiles[i].childObstacle = rockGO.GetComponent<Obstacle>();
                        }
                        break;
                    case 3:
                        {
                            GameObject mineralGO = Instantiate(mineralPrefab, tiles[i].transform);
                            tiles[i].childObstacleType = obstacleTypeArray[i];
                            tiles[i].childObstacle = mineralGO.GetComponent<Obstacle>();
                        }
                        break;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}