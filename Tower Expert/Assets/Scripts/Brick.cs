using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickColor
{
    Red = 1,
    Yellow = 10,
    Blue = 100
}

public class Brick : MonoBehaviour {

    public BrickColor color;

    public int[][] place;

    public void OnPlaced() {
        
    }
	
}
