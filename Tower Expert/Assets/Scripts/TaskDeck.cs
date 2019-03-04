using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDeck : Singleton<TaskDeck> {

    public List<TaskCard> tasks = new List<TaskCard>();
    private int TotalNum = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shuffle()
    {
        List<TaskCard> tempTasks = new List<TaskCard>(); 
        for(int i=0; i < TotalNum; i++){
            int index = Random.Range(0, tasks.Count);
            tempTasks.Add(tasks[index]);
            tasks.RemoveAt(index);
        }
        tasks = tempTasks;
    }
    public void InitDeck()
    {
        var internData = Resources.LoadAll<CardData>("TaskCards/Intern");
        var seniorData = Resources.LoadAll<CardData>("TaskCards/Senior");
        foreach(var t in internData)
        {         
            tasks.Add(new TaskCard(t));
            TotalNum++;
        }
        foreach (var t in seniorData)
        {
            tasks.Add(new TaskCard(t));
            TotalNum++;
        }
    }
    public TaskCard DrawTask()
    {
        int index = Random.Range(0, TotalNum);
        TaskCard task = tasks[index];
        tasks.RemoveAt(index);
        TotalNum--;
        return task;
    }

}
