using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType {
    Intern,
    Senior
}
[System.Serializable]
public class TaskCard {

    public CardData taskData;
    public TaskType taskType;
    
    public bool isCompleted = false;
    public TaskCard(CardData data)
    {
        taskData = data;
    }


    public int GetColorValue() {
        int colorValue = 0;
        foreach (BrickColor color in taskData.colors) {
            colorValue += (int)color;
        }
        return colorValue;
    }

    public void OnCompleted() {
        isCompleted = true;

        //Score
    }
    
}
