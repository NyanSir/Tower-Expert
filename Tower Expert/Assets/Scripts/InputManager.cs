using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {

                if (hitInfo.collider.gameObject != null)
                {

                    //When click on a BRICK
                    if (hitInfo.collider.gameObject.tag == "Brick")
                    {
                        if (GameManager.Instance.CurrentGameState == GameState.Idle)
                        {
                            Debug.Log("Hit a BRICK: " + hitInfo.collider.gameObject.name);

                            GameManager.Instance.CurrentGameState = GameState.BrickSelected;
                            GameManager.Instance.selectedBrick = hitInfo.collider.GetComponent<Brick>();
                        }
                    }

                    //When click on a TASK CARD
                    if (hitInfo.collider.gameObject.tag == "Task")
                    {

                    }

                    //When click on the BOARD
                    if (hitInfo.collider.gameObject.tag == "Board")
                    {
                        if (GameManager.Instance.CurrentGameState == GameState.BrickSelected)
                        {
                            Debug.Log("Put BRICK: " + GameManager.Instance.selectedBrick.color.ToString()
                                    + " , Onto BOARD: " + hitInfo.collider.gameObject.name);

                            // The BRICK can *ONLY* be placed in the BOARD COLUM that is not full
                            if (BoardManager.Instance.PlaceBrickAt(GameManager.Instance.selectedBrick, hitInfo.collider.GetComponent<BoardColum>()))
                            {
                                GameManager.Instance.CurrentGameState = GameState.Idle;
                            } else {
                                Debug.Log("Invalid BOARD COLUM");
                            }
                        }
                    }

                    //When click on the DECK OF BRICK
                    if (hitInfo.collider.gameObject.tag == "BrickDeck")
                    {
                        //Nothing happened
                    }

                    //When click on the DECK OF TASK
                    if (hitInfo.collider.gameObject.tag == "TaskDeck")
                    {
                        if (GameManager.Instance.CurrentGameState == GameState.Idle)
                        {
                            Debug.Log("Hit the TASK DECK: " + hitInfo.collider.gameObject.name);

                            GameManager.Instance.CurrentGameState = GameState.DrawTask;
                        }
                    }

                }

            }
        }


    }
}
