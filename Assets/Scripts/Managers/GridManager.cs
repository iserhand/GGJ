using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int _width, _height;

        [SerializeField] Tile _tilePrefab;

        [SerializeField] Transform _cam;
        void Start()
        {
            GenerateGrid();
        }
        void GenerateGrid()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    var spawnedTile = Instantiate(_tilePrefab, new Vector3(x * 1.92f - 3.74f, y * 1.92f - 8.61f, 1), Quaternion.identity);
                    spawnedTile.name = $"Tile {x} {y}";
                    var isOffSet = ((x + y) % 2 == 0);
                }
            }

            //_cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
        }
    }
}