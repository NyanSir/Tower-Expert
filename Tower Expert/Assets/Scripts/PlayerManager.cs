using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager> {

    public List<Brick> bricksInHand;
    public List<TaskCard> tasksInHand;
    public int score = 0;

    [SerializeField] private int maxHandSize;
    private int taskCount;

	// Use this for initialization
	void Start () {
		
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
    }

}
