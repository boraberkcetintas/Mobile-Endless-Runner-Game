using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    #region
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Animator playerAnim;
    private void Start()
    {
        UpdateGameState(State.WaitToTap);
    }

    public State state;
    public enum State
    {
        WaitToTap,
        Playing,
        Dead,
        Win
    }


    public void UpdateGameState(State newState)
    {
        state = newState;

        switch (newState)
        {
            case State.WaitToTap:

                break;
            case State.Playing:
                playerAnim.SetBool("run", true);
                break;
            case State.Dead:
                break;
            case State.Win:
                break;
            default:
                Debug.Log("GameState değişiminde hata!");
                break;
        }
    }
}
