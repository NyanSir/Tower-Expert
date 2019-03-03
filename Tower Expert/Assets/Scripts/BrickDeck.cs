using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickDeck : Singleton<BrickDeck> 
{

    public Material[] Materials;
    public List<Brick> bricks;

    private int YellowBrickNum = 10;
    private int BlueBrickNum = 10;
    private int RedBrickNum = 10;
    private int TotalNum;

    public Brick OnDraw()
    {
        int index = Random.Range(0, TotalNum);
        Brick brick = bricks[index];
        bricks.RemoveAt(index);
        return brick;
    }

    public void InitDeck()
    {
        TotalNum = YellowBrickNum + RedBrickNum + RedBrickNum;
        for (int i = 0; i < YellowBrickNum; i++)
        {
            bricks.Add(new Brick(2));
        }
        for (int i = 0; i < BlueBrickNum; i++)
        {
            bricks.Add(new Brick(0));
        }
        for (int i = 0; i < RedBrickNum; i++)
        {
            bricks.Add(new Brick(1));
        }

    }


}


//randomBrickColor = Random.Range(0, 3);
//        Bricks[0].SetColor(randomBrickColor);
//MeshRenderer brickRenderer = Bricks[0].gameObject.GetComponent<MeshRenderer>();
//brickRenderer.material = Materials[randomBrickColor];

//        randomBrickColor = Random.Range(0, 3);
//        Bricks[1].SetColor(randomBrickColor);
//brickRenderer = Bricks[1].gameObject.GetComponent<MeshRenderer>();
//        brickRenderer.material = Materials[randomBrickColor];

//        randomBrickColor = Random.Range(0, 3);
//        Bricks[2].SetColor(randomBrickColor);
//brickRenderer = Bricks[2].gameObject.GetComponent<MeshRenderer>();
//        brickRenderer.material = Materials[randomBrickColor];