using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo)) {

                if (hitInfo.collider.gameObject.tag == "Brick") {
                    Debug.Log("Hit a brick: " + hitInfo.collider.gameObject.name);

                    //GameManager.Instance.CurrentGameState = GameState.Place;
                    GameManager.Instance.selectedBrick = hitInfo.collider.GetComponent<Brick>();
                }

            }

        }

	}

}
