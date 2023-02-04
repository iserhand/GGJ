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
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}