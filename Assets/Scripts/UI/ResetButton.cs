using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour, IPointerDownHandler
{
   
    public void OnPointerDown(PointerEventData eventData)
    {
        ResetGame();
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
