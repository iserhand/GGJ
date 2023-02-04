using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour, IPointerDownHandler
{
   
    public void OnPointerDown(PointerEventData eventData)
    {
        RestartGame();
    }
    public void RestartGame()
    {
        print(1);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
