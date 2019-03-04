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
                            GameManager.Instance.CurrentGameState = GameState.BrickSelected;
                            GameManager.Instance.selectedBrick = hitInfo.collider.GetComponent<Brick>();
                            GameManager.Instance.selectedBrick.transform.position += Vector3.up * 0.5f;
                        }
                        else if (GameManager.Instance.CurrentGameState == GameState.BrickSelected)
                        {
                            GameManager.Instance.selectedBrick.transform.position -= Vector3.up * 0.5f;
                            GameManager.Instance.selectedBrick = hitInfo.collider.GetComponent<Brick>();
                            GameManager.Instance.selectedBrick.transform.position += Vector3.up * 0.5f;
                        }
                    }

                    //When click on a TASK CARD
                    else if (hitInfo.collider.gameObject.tag == "Task")
                    {

                    }

                    //When click on the BOARD
                    else if (hitInfo.collider.gameObject.tag == "Board")
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
                    else if (hitInfo.collider.gameObject.tag == "BrickDeck")
                    {
                        //Nothing happened
                    }

                    //When click on the DECK OF TASK
                    else if (hitInfo.collider.gameObject.tag == "TaskDeck")
                    {
                        if (GameManager.Instance.CurrentGameState == GameState.Idle)
                        {
                            Debug.Log("Hit the TASK DECK: " + hitInfo.collider.gameObject.name);

                            GameManager.Instance.CurrentGameState = GameState.DrawTask;
                        }
                    }

                    else
                    {
                        if (GameManager.Instance.CurrentGameState == GameState.BrickSelected)
                        {
                            GameManager.Instance.selectedBrick.transform.position -= Vector3.up * 0.5f;
                            GameManager.Instance.CurrentGameState = GameState.Idle;
                        }
                    }
                }
            }
            else
            {
                if (GameManager.Instance.CurrentGameState == GameState.BrickSelected)
                {
                    GameManager.Instance.selectedBrick.transform.position -= Vector3.up * 0.5f;
                    GameManager.Instance.CurrentGameState = GameState.Idle;
                }
            }
        }


    }
}
