using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum GameState : int
{
    Initial = 1,
    Idle,
    BrickSelected,
    DrawBrick,
    DrawTask,
    End,
}

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private GameState currentGameState;
    private bool ContinousDrawTask = true;

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

        set
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
                        BrickDeck.Instance.InitDeck();
                        TaskDeck.Instance.InitDeck();
                        for (int i = 0; i < 3; i++)
                        {
                            PlayerManager.Instance.DrawBrick(PlayerManager.Instance.brickPositions[i].position);
                        }
                        CurrentGameState = GameState.Idle;
                        break;
                    case GameState.Idle:

                        break;
                    case GameState.BrickSelected:
                        //place                         ---> wait for click to place brick
                        break;
                    case GameState.DrawBrick:
                        //draw a brick after each placement
                        PlayerManager.Instance.DrawBrick(selectedBrick.transform.position);
                        break;
                    case GameState.DrawTask:
                        //if the player didn't continously draw taskcard, go ahead
                        if (ContinousDrawTask == true)
                        {
                            //draw a task
                            PlayerManager.Instance.DrawTaskCard();
                            ContinousDrawTask = false;
                        }
                        CurrentGameState = GameState.Idle;
                        break;
                    case GameState.End:
                        //check task finish status
                        //check the tower is full
                        CheckTaskCompletion();
                        ContinousDrawTask = true;
                        break;
                }
            }
        }
    }
    void Start()
    {
        CurrentGameState = GameState.Initial;
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

    private void CheckTaskCompletion()
    {
        //List<TaskCard> shouldComplete = new List<TaskCard>();
        //foreach (TaskCard task in PlayerManager.Instance.tasksInHand)
        //{
        //    List<BrickMatrix> matrices = BoardManager.Instance.GetBrickMatrices(task);
        //    foreach (BrickMatrix matrix in matrices)
        //    {

        //        int result = 0;
        //        bool[,] cells = new bool[3, 3];

        //        for (int i = 0; i < 3; i++)
        //        {
        //            for (int j = 0; j < 3; j++)
        //            {
        //                cells[2 - i, j] = task.taskData.GetCells()[i, j];
        //            }
        //        }

        //        for (int i = 0; i < 3; i++)
        //        {
        //            for (int j = 0; j < 3; j++)
        //            {
        //                if (cells[i, j])
        //                {
        //                    result += (int)matrix.bricks[i, j];
        //                }
        //            }
        //        }

        //        //If value is equal, complete this TASK
        //        if (result == task.GetColorValue())
        //        {
        //            shouldComplete.Add(task);
        //        }
        //    }
        //}

        //PlayerManager.Instance.CompleteTask(shouldComplete);

        List<int> completed = new List<int>();
        for (int n = PlayerManager.Instance.tasksInHand.Count - 1; n >= 0; n--)
        {
            List<BrickMatrix> matrices = BoardManager.Instance.GetBrickMatrices(PlayerManager.Instance.tasksInHand[n]);
            foreach (BrickMatrix matrix in matrices)
            {

                int result = 0;
                bool[,] cells = new bool[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        cells[2 - i, j] = PlayerManager.Instance.tasksInHand[n].taskData.GetCells()[i, j];
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (cells[i, j])
                        {
                            result += (int)matrix.bricks[i, j];
                        }
                    }
                }

                //If value is equal, complete this TASK
                if (result == PlayerManager.Instance.tasksInHand[n].GetColorValue())
                {
                    completed.Add(n);
                }
            }
        }

        PlayerManager.Instance.CompleteTask(completed);
    }

}
