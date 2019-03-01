using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstantiate : MonoBehaviour {
    public Camera testCamera;
    public List<GameObject> cardsPool;
    private List<GameObject> myCards;
    private float cardsInterval = 1.5f;
    // Use this for initialization
    void Start() {
        CardInit();
        
    }
	// Update is called once per frame
	void Update () {
        DrawCard();
        clickToDestory();
	}

    void CardInit()
    {
        myCards = new List<GameObject>();
        for (int i = 0; i < 3; i++)
        {
           
            myCards.Add(Instantiate(cardsPool[Random.Range(0, cardsPool.Count)], new Vector3(cardsInterval * i, 0.0f, 0.0f), Quaternion.identity));
            Debug.Log("Instantiate card " + (i+1));
        }
    }

    void DrawCard()
    {
        if (Input.GetKeyDown("q"))
        {
            
            if(myCards.Count < 3)
            {
                Debug.Log("Draw a card");
                myCards.Add(Instantiate(cardsPool[Random.Range(0, cardsPool.Count)], new Vector3(cardsInterval * myCards.Count, 0.0f, 0.0f), Quaternion.identity));
               
            }
            else
            {
                Debug.Log("No Draw");
            }
        }
    }

    void clickToDestory()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mRay = testCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit mHit;

            if(Physics.Raycast(mRay, out mHit))
            {
                if(mHit.collider.gameObject.tag == "myCards")
                {
                    Destroy(mHit.collider.gameObject);
                    myCards.Remove(mHit.collider.gameObject);
                    Debug.Log("MyCards" + myCards.Count);

                    for (int i = 0; i < myCards.Count; i++)
                    {

                        myCards[i].transform.position = new Vector3(cardsInterval * i, 0.0f, 0.0f);
                        Debug.Log("Instantiate card " + (i + 1));
                    }

                }
            }
        }
    }

}
