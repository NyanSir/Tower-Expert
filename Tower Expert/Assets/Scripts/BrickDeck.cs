using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickDeck : Deck {

    public Material[] Materials;
    public Brick[] Bricks;
    private int randomBrickColor;
    //private ParticleSystem particle;
    // Use this for initialization
    void Start () {
        InitBrick();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Shuffle()
    {

    }
    public void OnDraw(GameObject brick)
    {
        randomBrickColor = Random.Range(0, 3);
        
        MeshRenderer brickRenderer = brick.GetComponent<MeshRenderer>();
        brickRenderer.material = Materials[randomBrickColor];
        //particle = brick.GetComponentInChildren<ParticleSystem>();
        //particle.Play();
    }

    void InitBrick()
    {
        randomBrickColor = Random.Range(0, 3);
        Bricks[0].SetColor(randomBrickColor);
        MeshRenderer brickRenderer = Bricks[0].gameObject.GetComponent<MeshRenderer>();
        brickRenderer.material = Materials[randomBrickColor];

        randomBrickColor = Random.Range(0, 3);
        Bricks[1].SetColor(randomBrickColor);
        brickRenderer = Bricks[1].gameObject.GetComponent<MeshRenderer>();
        brickRenderer.material = Materials[randomBrickColor];

        randomBrickColor = Random.Range(0, 3);
        Bricks[2].SetColor(randomBrickColor);
        brickRenderer = Bricks[2].gameObject.GetComponent<MeshRenderer>();
        brickRenderer.material = Materials[randomBrickColor];


    }


}
