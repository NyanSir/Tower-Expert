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
   
    private bool isZoomIn;
    public int[][] place;

    public void OnPlaced() {
        
    }

    void Start()
    {
        
        this.transform.localScale = Vector3.one;
        
    }

    void Update()
    {

    }
	void OnMouseEnter()
    {
        transform.localScale =Vector3.one*2.0f;
    }
    void OnMouseExit()
    {
        //Debug.Log(1);
        transform.localScale = Vector3.one;
    }
    public void SetColor(int colorIndex)
    {
        if(colorIndex == 0)
        {
            color = BrickColor.Blue;

        }else if(colorIndex == 1)
        {
            color = BrickColor.Red;
        }
        else
        {
            color = BrickColor.Yellow;
        }
    }
   

}
