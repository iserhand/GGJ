using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerDownHandler
{
   
    public void OnPointerDown(PointerEventData eventData)
    {
        StartGame();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level",1));
    }
}
