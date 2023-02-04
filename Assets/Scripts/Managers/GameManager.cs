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
        private void Start()
        {
            UIManager.Instance.UpdateTourCountText();
            
        }
        public void ChangeTurnCount(int amount)
        {
            turnCount += amount;
            UIManager.Instance.UpdateTourCountText();
            if(turnCount==0)
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