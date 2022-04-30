using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public Animator playerAnimator;
    void Start()
    {
        UpdateGameState(GameState.WaitToTap);
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
                break;

            case GameState.Playing:
                playerAnimator.SetBool("run", true);
                break;

            case GameState.Dead:
                break;

            case GameState.Win:
                break;
        }
    }
}
