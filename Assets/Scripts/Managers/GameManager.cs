using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GGJ
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public int turnCount = 12;
        public int targetMineralCount = 12;
        public RootAnimation rootAnimationSc;
        public Tile currentTile;
        public bool isGamePlayable=true;
        public List<Tile> printedTiles = new List<Tile>();
        public int totalCollectedBottle,thisLevelCollectedBottle;
        private void Awake()
        {
            MakeSingleton();
            totalCollectedBottle = PlayerPrefs.GetInt("bottle", 0);
           
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
        private void Start()
        {
            UIManager.Instance.UpdateTotalBottleText();
            UIManager.Instance.UpdateTourCountText();
            
        }
        public void ChangeTurnCount(int amount)
        {
            turnCount += amount;
            UIManager.Instance.UpdateTourCountText();
            if(turnCount<=0)
            {
                LoseGame();
            }
        }
        public void DecreaseRequiredMineralCount()
        {
            targetMineralCount--;
            UIManager.Instance.UpdateRequiredMineralText();
            if(targetMineralCount==0)
            {
                FindObjectOfType<Door>().OpenDoor();
            }
        }
        public void UpdateMoveableGrids()
        {
            for(int i =0;i<printedTiles.Count;i++)
            {
                printedTiles[i].ResetPrint();
            }
            printedTiles.Clear();
            for (int i = 0; i < currentTile.neighbourTiles.Count; i++)
            {
                if (currentTile.neighbourTiles[i].childObstacleType != 2)
                {
                    currentTile.neighbourTiles[i].PrintToMoveable();
                    printedTiles.Add(currentTile.neighbourTiles[i]);
                }
            }
        }
        public void LoseGame()
        {
            UIManager.Instance.OpenRestartUI();
            isGamePlayable = false;
        }
        public void WinGame()
        {
            UIManager.Instance.OpenWinUI();
            isGamePlayable = false;
        }
    }
}