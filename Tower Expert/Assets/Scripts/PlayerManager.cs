using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager> {

    public List<Brick> bricksInHand;
    public List<TaskCard> tasksInHand;
    public GameObject[] taskPos;
    public GameObject taskcard;
    public int score = 0;
    private GameObject[] UItaskInHand = new GameObject[3];

    public GameObject playerHand;
    public Text scoreUI;
    [SerializeField] private Transform[] brickPositions;

    [SerializeField] private int maxHandSize;
    private int taskCount;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 3; i++) {
            DrawBrick(brickPositions[i].position);
        }
        for (int i = 0; i < 3; i++)
        {
            UItaskInHand[i] = null;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void DrawBrick(Vector3 position) {
        bricksInHand.Add(BrickDeck.Instance.OnDraw(position));
    }

    public void UseBrick(Brick usedBrick) {
        bricksInHand.Remove(usedBrick);
    }

    public void DrawTaskCard() {
        if (tasksInHand.Count < 3)
        {
            tasksInHand.Add(TaskDeck.Instance.DrawTask());
            UIUpdateHand();           
        }
        GameManager.Instance.CurrentGameState = GameState.Idle;
    }

    public void AddTask(TaskCard task) {
        tasksInHand.Add(task);
        taskCount++;
    }

    public void CompleteTask(TaskCard task) {
        tasksInHand.Remove(task);
        taskCount--;

        //Scoring
        score += task.taskData.score;
        scoreUI.text = score + "";
    }
    public void UIUpdateHand()
    {       
        for(int n = 0; n < 3; ++n)
        {
            if(UItaskInHand[n] != null)
                Destroy(UItaskInHand[n]);
        }
        Transform cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        int i = 0;
        foreach(TaskCard t in tasksInHand)
        {
            taskcard.GetComponent<TaskCardGenerator>().Data = t.taskData;
            UItaskInHand[i] = Instantiate(taskcard, taskPos[i].transform.position, taskPos[i].transform.rotation, taskPos[i].transform);
            i++;
        }
    }
}
