using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour, IPointerDownHandler
{
   
    public void OnPointerDown(PointerEventData eventData)
    {
        NextGame();
    }
    public void NextGame()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 1) + 1);
        if(PlayerPrefs.GetInt("level")>=SceneManager.sceneCount)
        {
            PlayerPrefs.SetInt("level", 1);
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
    }
}
