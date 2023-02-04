using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public int turnCount = 12;
        public RootAnimation rootAnimationSc;
        public Tile currentTile;
        private void Awake()
        {
            MakeSingleton();
        }

        private void MakeSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}