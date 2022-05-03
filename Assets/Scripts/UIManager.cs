using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GManager gManagerScript; // gManagerScript türünü tanımladım.

    void Start()
    {
        //Game Manager Scriptini buluyor ve değişkene atıyor.
        gManagerScript = GameObject.Find("Game Manager").GetComponent<GManager>();
    }


    public void StartGame() // "Başlamak için dokun" yazısı ekrandayken tıklayınca oyunu başlatıyor.
    {
        gManagerScript.UpdateGameState(GManager.GameState.Playing);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
