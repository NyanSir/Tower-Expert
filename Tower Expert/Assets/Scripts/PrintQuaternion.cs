using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintQuaternion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(gameObject.name + "  Local Quaternion: " + transform.localRotation.ToString("F6"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
