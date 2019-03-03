using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : Singleton<PlayerManager> {

    public List<Brick> bricksInHand;
    public List<TaskCard> tasksInHand;
    public int score = 0;

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
        tasksInHand.Add(TaskDeck.Instance.DrawTask());
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

}
