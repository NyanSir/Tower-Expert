using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickColor
{
    Red = 1,
    Yellow = 10,
    Blue = 100,
    Error = 0
}

public class Brick : MonoBehaviour {
    public BrickColor color;
   
    private bool isZoomIn;
    //public int[][] place;

    public Brick(int colorIndex)
    {
        if (colorIndex == 0)
        {
            color = BrickColor.Blue;

        }
        else if (colorIndex == 1)
        {
            color = BrickColor.Red;
        }
        else
        {
            color = BrickColor.Yellow;
        }
    }

    //void OnMouseEnter() {
    //    transform.localScale = Vector3.one * 2.0f;
    //}

    //void OnMouseExit() {
    //    transform.localScale = Vector3.one;
    //}

    public void OnPlaced() {
        //Maybe some visual effects when placed
        GetComponent<Collider>().enabled = false;
    }

}
