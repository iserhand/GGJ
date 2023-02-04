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
            UIManager.Instance.UpdateRequiredMineralText();
        }
        public void ChangeTurnCount(int amount)
        {
            turnCount += amount;
            UIManager.Instance.UpdateTourCountText();
            if(turnCount==0)
            {
                //TODO
            }
        }
        public void DecreaseRequiredMineralCount()
        {
            targetMineralCount--;
            UIManager.Instance.UpdateRequiredMineralText();
            if(targetMineralCount==0)
            {
                //TODO
            }
        }
        public void LoseGame()
        {

        }
    }
}