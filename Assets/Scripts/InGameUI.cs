//using ElephantSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text levelText;
    public GameObject levelCompletePanel;
    public GameObject levelFailPanel;
    public GameObject tutorialPanel;
    public GameObject tapToStartPanel;
    public GameObject confettiRain;
    public GameObject pauseButton;
    public GameObject levelIndicator;
    //public GameObject progressIndicator;
    [HideInInspector] public bool levelFinished;
    [HideInInspector] public bool levelStarted;

    // Start is called before the first frame update
    void Start()
    {
        if (SaveLoadManager.getLastPlayedLevel() != SceneManager.GetActiveScene().buildIndex)
        {
            //SceneManager.LoadScene(SaveLoadManager.getLastPlayedLevel());
        }
        levelText.text = "Level " + SaveLoadManager.getFakeLevel().ToString();

        //Elephant.LevelStarted(SaveLoadManager.getFakeLevel());

        //tapToStartPanel.SetActive(true);

        if (SaveLoadManager.getFakeLevel() != 1)
        {
            //
        }
        else
        {
            //tutorialPanel.SetActive(true);
        }
        Time.timeScale = 1;

        if ((float)Screen.height / (float)Screen.width < 1.6f)      //2048 screen
            GetComponent<CanvasScaler>().referenceResolution = new Vector2(3000, 1080);
        else if ((float)Screen.height / (float)Screen.width < 1.95f)    //1080 screen
            GetComponent<CanvasScaler>().referenceResolution = new Vector2(2200, 1080);
        else        //1242 screen
            GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void StartLevel()
    {
        levelStarted = true;
        tutorialPanel.SetActive(false);
        tapToStartPanel.SetActive(false);

        GameManager.GetInstance().UpdateGameState(GameManager.State.Playing);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SaveLoadManager.increaseFakeLevel();
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            int randomLevel = Random.Range(2, 4);
            SaveLoadManager.setLastPlayedLevel(1);
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SaveLoadManager.setLastPlayedLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public IEnumerator levelComplete()
    {
        //Elephant.LevelCompleted(SaveLoadManager.getFakeLevel());

        levelFinished = true;
        yield return new WaitForSeconds(0.2f);
        pauseButton.SetActive(false);
        levelIndicator.SetActive(false);
        //progressIndicator.SetActive(false);
        levelCompletePanel.SetActive(true);
        confettiRain.SetActive(true);
    }

    public IEnumerator levelFail()
    {
        //Elephant.LevelFailed(SaveLoadManager.getFakeLevel());

        levelFinished = true;
        yield return new WaitForSeconds(0.2f);
        pauseButton.SetActive(false);
        //progressIndicator.SetActive(false);
        levelIndicator.SetActive(false);
        levelFailPanel.SetActive(true);
    }

}
