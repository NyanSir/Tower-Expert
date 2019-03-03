using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BrickMatrix
{
    public BrickColor[,] bricks;
}

public class BoardManager : Singleton<BoardManager>
{

    public BoardColum[] boardColums;

    public int maxBrickPerColum;
    public float brickHeight;

    private int maxBrickCount;
    private int brickCount;

    // Use this for initialization
    void Start()
    {
        brickCount = 0;
        maxBrickCount = maxBrickPerColum * boardColums.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool PlaceBrickAt(Brick brick, BoardColum colum)
    {
        if (!colum.isFull)
        {
            PlayerManager.Instance.UseBrick(brick);
            PlayerManager.Instance.DrawBrick(brick.transform.position);
            colum.PlaceBrick(brick);

            row = colum.brickCount - 1;
            col = colum.index;
        }
        else
        {
            return false;
        }

        if (++brickCount >= maxBrickCount)
        {
            OnFull();
        }

        GameManager.Instance.CurrentGameState = GameState.End;
        return true;
    }

    private int row;
    private int col;
    public List<BrickMatrix> GetBrickMatrices(TaskCard task)
    {
        List<BrickMatrix> matrices = new List<BrickMatrix>();
        bool[,] cells = new bool[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                cells[i, 2 - j] = task.taskData.GetCells()[i, j];
            }
        }

        int r = row;
        int c = col;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (cells[i, j])
                {
                    int x = r - i;
                    int y = c - j;

                    for (int a = 0; a < 3; a++)
                    {
                        for (int b = 0; b < 3; b++) {
                            int p = x + a;
                            int q = y + b;
                            BrickMatrix m = new BrickMatrix();
                            if (p < 0 || p > 2 || q < 0 || q >= maxBrickPerColum) {                               
                                m.bricks[a, b] = BrickColor.Error;                                
                            } else {
                                m.bricks[a, b] = GetBrickAt(p, q).color;
                            }
                            matrices.Add(m);
                        }
                    }

                }
            }
        }

        return matrices;
    }

    private void OnFull()
    {
        //End the game
        //Calculate the points and display it
        //display game ends
    }

    public Brick GetBrickAt(int r, int c)
    {
        return boardColums[c].bricks[r];
    }

}
