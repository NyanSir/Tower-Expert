using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum GameState : int
{
    Initial = 0,
    SelectBrick,
    Place,
    DrawBrick,
    DrawTask,
    End,
}

public class GameManager : Singleton<GameManager> {
    
    /// <summary>
    /// Singleton
    /// </summary>
    public static GameManager Instance = null;

    private GameState currentGameState;
    private bool ContinousDrawTask = true;

    private TaskDeck taskDeck;
    private BrickDeck brickDeck;

    public Brick selectedBrick;

    /// <summary>
    /// CurrentGameState for other script to call
    /// </summary>
    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
        }

        private set
        {
            if (value == currentGameState)
            {
                LogUtility.PrintLogFormat("GameManager", "Reset {0}.", value);
            }
            else
            {
                LogUtility.PrintLogFormat("GameManager", "Made a transition to {0}.", value);

                //GameState previousGameState = CurrentGameState;
                currentGameState = value;
                switch (currentGameState)
                {
                    case GameState.Initial:
                        ///Initial bricks and tasks     ---> Shuffle decks ---> deal bricks and taskcards
                        
                        break;
                    case GameState.Place:
                        //place                         ---> wait for click to place brick

                        CurrentGameState = GameState.DrawBrick;     //after each placement player must draw one brick
                        break;
                    case GameState.DrawBrick:
                        //draw a brick after each placement
                        break;
                    case GameState.DrawTask:
                        //if the player didn't continously draw taskcard, go ahead
                        if(ContinousDrawTask == true)
                        {
                            //draw a task

                            ContinousDrawTask = false;
                        }
                        break;
                    case GameState.End:
                        //check task finish status
                        //check the tower is full
                        break;
                }
            }
        }
    }
    void Start()
    {
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            CurrentGameState = GameState.Initial;
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

}
