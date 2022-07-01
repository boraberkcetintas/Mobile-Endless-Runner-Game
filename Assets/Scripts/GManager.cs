using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public Animator playerAnimator;
    public GameObject gameOverPanel;
    public GameObject pauseButton;
    public GameObject inGameScoreText;
    public PlayerController playerScript;
    public AudioSource audioSource;
    public AudioClip deadSFX;
    public Text bestScore;
    void Start()
    {
        UpdateGameState(GameState.WaitToTap);
        playerScript = GameObject.Find("Stickman (1)").GetComponent<PlayerController>();
        audioSource = GameObject.Find("Stickman (1)").GetComponent<AudioSource>();
    }

    public enum GameState
    {
        WaitToTap,
        Playing,
        Dead,
        Win
    }

    public GameState state;


    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.WaitToTap:
                Time.timeScale = 1;
                break;

            case GameState.Playing:
                playerAnimator.SetBool("run", true);
                Time.timeScale = 1;
                break;

            case GameState.Dead:
                audioSource.Stop(); // Müziği durdurur
                gameOverPanel.gameObject.SetActive(true); // Ölüm anında game over panelini açıyor
                pauseButton.gameObject.SetActive(false);  // ölümn anında pause butonunu kapıyor
                inGameScoreText.gameObject.SetActive(false); // ölüm anında oyun içi skor yazısını kapıyor

                if(playerScript.score > int.Parse(PlayerPrefs.GetString("Best Score", "0"))) // Eğer score Best skordan büyükse o anki skoru yeni best skor yapıyor.
                {                                                                            // PlayerPrefs.GetString değeri çekiyor ve int.Parse string değerini int hale getiriyor.
                    PlayerPrefs.SetString("Best Score", playerScript.score.ToString());     // int hale gelen best skor değeri ile > operatörünü kullanıyoruz.
                }
                
                audioSource.PlayOneShot(deadSFX);
               
                bestScore.text = "Best " + PlayerPrefs.GetString("Best Score") + " M"; // Game Over ekranındaki best score yazısını değiştiriyor.
                break;

            case GameState.Win: //Win yok
                break;
        }
    }
}
