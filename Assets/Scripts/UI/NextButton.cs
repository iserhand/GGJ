using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
namespace GGJ {
    public class NextButton : MonoBehaviour, IPointerDownHandler
    {

        public void OnPointerDown(PointerEventData eventData)
        {
            NextGame();
        }
        public void NextGame()
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 1) + 1);
            if (PlayerPrefs.GetInt("level") <= SceneManager.sceneCount)
            {
                PlayerPrefs.SetInt("level", 1);
            }
            PlayerPrefs.SetInt("bottle", GameManager.Instance.totalCollectedBottle + GameManager.Instance.thisLevelCollectedBottle);
    
        SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
        }
    }
}