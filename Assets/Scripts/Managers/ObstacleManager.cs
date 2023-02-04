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
        public GameObject wormPrefab;
        public GameObject bottlePrefab;
        public GameObject doorPrefab;
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
                            break;
                        }
                    case 2:
                        {
                            GameObject rockGO = Instantiate(rockPrefab, tiles[i].transform);
                            tiles[i].childObstacleType = obstacleTypeArray[i];
                            tiles[i].childObstacle = rockGO.GetComponent<Obstacle>();
                            break;
                        }
                    case 3:
                        {
                            GameObject mineralGO = Instantiate(mineralPrefab, tiles[i].transform);
                            tiles[i].childObstacleType = obstacleTypeArray[i];
                            tiles[i].childObstacle = mineralGO.GetComponent<Obstacle>();
                            GameManager.Instance.targetMineralCount++;
                            break;
                        }
                    case 4:
                        {
                            GameObject wormGO = Instantiate(wormPrefab, tiles[i].transform);
                            tiles[i].childObstacleType = obstacleTypeArray[i];
                            tiles[i].childObstacle = wormGO.GetComponent<Obstacle>();
                            break;
                        }
                    case 5:
                        {
                            GameObject bottleGO = Instantiate(bottlePrefab, tiles[i].transform);
                            tiles[i].childObstacleType = obstacleTypeArray[i];
                            tiles[i].childObstacle = bottleGO.GetComponent<Obstacle>();
                            break;
                        }
                    case 6:
                        {
                            GameObject doorGO = Instantiate(doorPrefab, tiles[i].transform);
                            tiles[i].childObstacleType = obstacleTypeArray[i];
                            tiles[i].childObstacle = doorGO.GetComponent<Obstacle>();
                            break;
                        }
                }
            }
            UIManager.Instance.UpdateRequiredMineralText();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}