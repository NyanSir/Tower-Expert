using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBoardManager : Singleton<GridBoardManager> {

    public Brick[][] bricks;

    private int brickCount;
    
	// Use this for initialization
	void Start () {
        brickCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaceBrickAt(Brick brick, int colum) {
        brickCount++;
    }

    public void GetBrickMatrix(int row, int colum) {
        
    }

}
