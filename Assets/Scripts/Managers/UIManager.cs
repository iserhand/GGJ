using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace GGJ
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        public TextMeshProUGUI tourCountText;
        public TextMeshProUGUI requiredMineralText;

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
        public void UpdateTourCountText()
        {
            tourCountText.text = "Turn Count:" + GameManager.Instance.turnCount.ToString();
        }
        public void UpdateRequiredMineralText()
        {
            requiredMineralText.text = "x" + GameManager.Instance.targetMineralCount;
        }
    }
}