using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TaskType {
    Intern,
    Senior
}

public class TaskCard : MonoBehaviour {

    public CardData taskData;

    public bool isCompleted = false;

    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
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
