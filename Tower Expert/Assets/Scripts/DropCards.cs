using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCards : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //GameObject.Destroy(gameObject, 3.0f);
    }
	
	// Update is called once per frame
	void Update () {
        //clickToDestory();
	}

    void clickToDestory()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit mHit;

            if (Physics.Raycast(mRay, out mHit))
            {
                if (mHit.collider.gameObject.tag == "myCards")
                {
                    Destroy(mHit.collider.gameObject);

                   
                }
            }
        }
    }
}
