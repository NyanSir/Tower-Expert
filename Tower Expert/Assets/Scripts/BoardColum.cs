using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardColum : MonoBehaviour {

    public int index;
    public bool isFull = false;

    public Brick[] bricks;
    public int brickCount = 0;

    private float brickHeight;

    // Use this for initialization
    void Start () {
        GetComponent<MeshRenderer>().enabled = false;
        bricks = new Brick[BoardManager.Instance.maxBrickPerColum];

        brickHeight = BoardManager.Instance.brickHeight;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaceBrick(Brick brick) {
        bricks[brickCount] = brick;

        //Visual effect of BRICK placement
        brick.transform.position = transform.position + new Vector3(0, brickHeight * brickCount, 0);
        brick.OnPlaced();
        
        if (++brickCount >= BoardManager.Instance.maxBrickPerColum) {
            isFull = true;
        }
    }

}
