using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {
    public BrickDeck brickDeck;
    public Camera testCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            BrickHitTest();
        }
		
	}
    void BrickHitTest()
    {
        RaycastHit brickHit;
        Ray customRay;
        customRay = testCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(customRay, out brickHit))
        {
            if(brickHit.collider.gameObject != null && brickHit.collider.tag.Equals("Brick"))
            {
                Debug.Log(brickHit.collider.name);
                DrawBrick(brickHit.collider.gameObject);
                
            }
        }
    }
    void DrawBrick(GameObject brick)
    {
        brickDeck.OnDraw(brick);
    }
}
